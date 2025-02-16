using CleanArch.API.Infrastructure.Repositories;
using MediatR;

namespace CleanArch.API.Application.Queries.EmployeeQueries
{
    public class CreateEmployeeQueryHandler : IRequestHandler<CreateEmployeeQuery, string>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public CreateEmployeeQueryHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<string> Handle(CreateEmployeeQuery request, CancellationToken cancellationToken)
        {
            // Create a new Employee entity and set its properties
            var employee = new Employee
            {
                Id = "UI" + Guid.NewGuid().ToString().Substring(0, 7), // Create a unique employee ID
                Name = request.Name,
                EmailAddress = request.EmailAddress,
                PhoneNumber = request.PhoneNumber,
                Gender = request.Gender,
                StartDate = request.StartDate,
                CafeId = request.CafeId // Link the employee to the specified cafe
            };

            // Call the repository to save the new employee
            await _employeeRepository.AddEmployeeAsync(employee);

            // Return the new employee's ID
            return employee.Id;
        }
    }
}
