using CleanArch.API.Application.Commands.CafeCommands;
using CleanArch.API.Domain.DTOs;
using CleanArch.API.Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.API.Application.Queries.CafeQueries
{
    public class GetAllCafesQueryHandler(ICafeRepository cafeRepository) : IRequestHandler<GetAllCafesQuery, List<CafeDTO>>
    {
        private readonly ICafeRepository _cafeRepository = cafeRepository;
        public async Task<List<CafeDTO>> Handle(GetAllCafesQuery request, CancellationToken cancellationToken)
        {
            var cafes = await _cafeRepository.GetCafesAsync();
            var cafeDtos = cafes.Select(c => new CafeDTO
            {
                Id = c.CafeId,
                Name = c.Name,
                Description = c.Description,
                //Employees = c.Employees.Count,
                 Logo = c.Logo,  // Optional
                 Location = c.Location
            }).ToList();
            return cafeDtos; // Return all cafes);
        }
    }


}
