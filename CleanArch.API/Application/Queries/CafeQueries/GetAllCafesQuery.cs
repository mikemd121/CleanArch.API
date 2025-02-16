using CleanArch.API.Domain.DTOs;
using MediatR;

namespace CleanArch.API.Application.Queries.CafeQueries
{

    public class GetAllCafesQuery : IRequest<List<CafeDTO>>
    {
        // You can keep properties like 'Location' if they will be optional
        // public string Location { get; set; }
    }
}
