using CleanArch.API.Domain.DTOs;
using CleanArch.API.Infrastructure.Repositories;
using MediatR;

namespace CleanArch.API.Application.Commands.CafeCommands
{
    public class GetCafesQueryHandler(ICafeRepository cafeRepository) : IRequestHandler<GetCafesQuery, List<CafeDTO>>
    {
        private readonly ICafeRepository _cafeRepository = cafeRepository;

        public async Task<List<CafeDTO>> Handle(GetCafesQuery request, CancellationToken cancellationToken)
        {
            var cafes = await _cafeRepository.GetCafesAsync();

            if (!string.IsNullOrEmpty(request.Location))
                cafes = cafes.Where(c => c.Location.Equals(request.Location, StringComparison.OrdinalIgnoreCase)).ToList();

            var sortedCafes = cafes
          .OrderByDescending(c => c.Employees.Count) 
          .ToList();

            var cafeDtos = sortedCafes.Select(c => new CafeDTO
            {
                Id = c.CafeId,
                Name = c.Name,
                Description = c.Description,
                Employees = c.Employees.Count,
                Logo = c.Logo != null ? Convert.ToBase64String(c.Logo) : null,
                Location = c.Location
            }).ToList();

            return cafeDtos;
        }
    }
}
