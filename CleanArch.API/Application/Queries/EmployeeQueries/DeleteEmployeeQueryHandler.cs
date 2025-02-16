using CleanArch.API.Infrastructure.Repositories;
using MediatR;

namespace CleanArch.API.Application.Queries.EmployeeQueries
{
    public class DeleteEmployeeQueryHandler : IRequestHandler<DeleteEmployeeQuery, bool>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public DeleteEmployeeQueryHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<bool> Handle(DeleteEmployeeQuery request, CancellationToken cancellationToken)
        {
            // Fetch the employee by ID
            var employee = await _employeeRepository.GetEmployeeByIdAsync(request.EmployeeId);
            if (employee == null)
            {
                return false; // Employee not found
            }

            // Delete the employee
            await _employeeRepository.DeleteEmployeeAsync(employee);

            return true; // Successfully deleted
        }
    }
}
