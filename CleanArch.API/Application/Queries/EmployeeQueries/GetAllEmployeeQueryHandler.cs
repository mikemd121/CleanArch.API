using CleanArch.API.Domain.DTOs;
using CleanArch.API.Infrastructure.Repositories;
using MediatR;

namespace CleanArch.API.Application.Queries.EmployeeQueries;

    public class GetAllEmployeeQueryHandler(IEmployeeRepository  employeeRepository ) : IRequestHandler<GetAllEmployeeQuery, List<EmployeeDTO>>
    {
        private readonly IEmployeeRepository _employeeRepository = employeeRepository;
        public async Task<List<EmployeeDTO>> Handle(GetAllEmployeeQuery request, CancellationToken cancellationToken)
        {
        var employees = await _employeeRepository.GetAllEmployees();
            var employeeDtos = employees.Select(c => new EmployeeDTO
            {
                Id = c.Id,
                Name = c.Name,
                EmailAddress = c.EmailAddress,
                PhoneNumber = c.PhoneNumber,
                Gender = c.Gender,
                DaysWorked = (int)(DateTime.Now - c.StartDate).TotalDays,
                Cafe = c.Cafe?.Name ?? string.Empty 
            }).ToList();
            return employeeDtos;
        }
    }

