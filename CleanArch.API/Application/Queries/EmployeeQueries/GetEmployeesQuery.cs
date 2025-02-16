using CleanArch.API.Domain.DTOs;
using MediatR;
using System;


namespace CleanArch.API.Application.Queries.EmployeeQueries
{
    public class GetEmployeesQuery : IRequest<List<EmployeeDTO>>
    {
        public string Cafe { get; set; } // Optionally filter by café
    }

}
