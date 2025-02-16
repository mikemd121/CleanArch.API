using CleanArch.API.Domain.DTOs;
using CleanArch.API.Infrastructure.Repositories;
using MediatR;

namespace CleanArch.API.Application.Queries.EmployeeQueries
{
    public class GetEmployeesQueryHandler : IRequestHandler<GetEmployeesQuery, List<EmployeeDTO>>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public GetEmployeesQueryHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<List<EmployeeDTO>> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
        {
            // Get all employees, or filter by café if provided
            var employeesQuery = await _employeeRepository.GetEmployeesAsync(request.Cafe);

            // Map the employees to DTOs
            var employeeDtos = employeesQuery.Select(e => new EmployeeDTO
            {
                Id = e.Id,
                Name = e.Name,
                EmailAddress = e.EmailAddress,
                PhoneNumber = e.PhoneNumber,
                Gender=e.Gender,
                DaysWorked = (int)(DateTime.Now - e.StartDate).TotalDays, // Calculate days worked
                Cafe = e.Cafe?.Name ?? string.Empty // Get the cafe's name or empty string
            })
            .OrderByDescending(e => e.DaysWorked) // Sort by highest number of days worked
            .ToList();

            return employeeDtos;
        }
    }
}
