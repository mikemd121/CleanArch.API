using CleanArch.API.Domain.DTOs;
using MediatR;

namespace CleanArch.API.Application.Queries.EmployeeQueries
{
    public class GetAllEmployeeQuery : IRequest<List<EmployeeDTO>>
    {

    }
}
