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

            // If a location is provided, filter the cafes by location
            if (!string.IsNullOrEmpty(request.Location))
            {
                cafes = cafes.Where(c => c.Location.Equals(request.Location, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            // Sort by number of employees, highest first
            var sortedCafes = cafes
          .OrderByDescending(c => c.Employees.Count) // Sort by the count of employees
          .ToList();

            // Map the cafes to the DTO
            var cafeDtos = sortedCafes.Select(c => new CafeDTO
            {
                Id = c.CafeId,
                Name = c.Name,
                Description = c.Description,
                Employees = c.Employees.Count,
                Logo = c.Logo,  // Optional
                Location = c.Location
            }).ToList();

            return cafeDtos;
        }
    }
}
