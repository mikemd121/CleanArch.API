﻿using CleanArch.API.Domain.DTOs;
using MediatR;


namespace CleanArch.API.Application.Queries.EmployeeQueries
{
    public class GetEmployeesQuery : IRequest<List<EmployeeDTO>>
    {
        public required string Cafe { get; set; }
    }

}
