using CleanArch.API.Infrastructure.Repositories;
using MediatR;

namespace CleanArch.API.Application.Queries.EmployeeQueries
{
    public class UpdateEmployeeQueryHandler : IRequestHandler<UpdateEmployeeQuery, bool>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public UpdateEmployeeQueryHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<bool> Handle(UpdateEmployeeQuery request, CancellationToken cancellationToken)
        {
            // Fetch the employee by their ID
            var employee = await _employeeRepository.GetEmployeeByIdAsync(request.Id);
            if (employee == null)
            {
                return false; // Employee not found
            }

            // Update the employee's properties
            employee.Name = request.Name;
            employee.EmailAddress = request.EmailAddress;
            employee.PhoneNumber = request.PhoneNumber;
            employee.Gender = request.Gender;
            employee.StartDate = request.StartDate;
            employee.CafeId = request.CafeId;

            // Save the changes to the database
            await _employeeRepository.UpdateEmployeeAsync(employee);

            return true; // Successfully updated
        }

    }
}
