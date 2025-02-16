using CleanArch.API.Domain.DTOs;
using MediatR;

namespace CleanArch.API.Application.Queries.CafeQueries
{

    public class GetAllCafesQuery : IRequest<List<CafeDTO>>
    {

    }
}
