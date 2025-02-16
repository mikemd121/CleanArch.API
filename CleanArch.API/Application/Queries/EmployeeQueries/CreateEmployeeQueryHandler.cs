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

            var employee = new Employee
            {
                Id = "UI" + Guid.NewGuid().ToString().Substring(0, 7), 
                Name = request.Name,
                EmailAddress = request.EmailAddress,
                PhoneNumber = request.PhoneNumber,
                Gender = request.Gender,
                StartDate = request.StartDate,
                CafeId = request.CafeId 
            };

            await _employeeRepository.AddEmployeeAsync(employee);

            return employee.Id;
        }
    }
}
