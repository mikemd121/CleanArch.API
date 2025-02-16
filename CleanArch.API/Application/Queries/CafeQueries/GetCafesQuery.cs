using CleanArch.API.Domain.DTOs;
using MediatR;

namespace CleanArch.API.Application.Commands.CafeCommands
{
    public class GetCafesQuery : IRequest<List<CafeDTO>>
    {
        public required string Location { get; set; }
    }


}
