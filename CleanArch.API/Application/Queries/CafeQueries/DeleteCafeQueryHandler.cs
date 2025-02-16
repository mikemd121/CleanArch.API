using CleanArch.API.Infrastructure.Repositories;
using MediatR;

namespace CleanArch.API.Application.Queries.CafeQueries
{
    public class DeleteCafeQueryHandler : IRequestHandler<DeleteCafeQuery, bool>
    {
        private readonly ICafeRepository _cafeRepository;
        private readonly IEmployeeRepository _employeeRepository;

        public DeleteCafeQueryHandler(ICafeRepository cafeRepository, IEmployeeRepository employeeRepository)
        {
            _cafeRepository = cafeRepository;
            _employeeRepository = employeeRepository;
        }

        public async Task<bool> Handle(DeleteCafeQuery request, CancellationToken cancellationToken)
        {
            var cafe = await _cafeRepository.GetCafeByIdAsync(request.CafeId);
            if (cafe == null)
            {
                return false;
            }

        
            var employees = cafe.Employees; 
            if (employees != null)
            {
                foreach (var employee in employees)
                {
                    await _employeeRepository.DeleteEmployeeAsync(employee);
                }
            }


            await _cafeRepository.DeleteCafeAsync(cafe);

            return true; 
        }
    }
}
