using Microsoft.EntityFrameworkCore;

namespace CleanArch.API.Infrastructure.Repositories
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetEmployeesAsync(string cafeName);
        Task AddEmployeeAsync(Employee employee); // Add employee method

        Task<Employee> GetEmployeeByIdAsync(string employeeId);
        Task UpdateEmployeeAsync(Employee employee);

        Task DeleteEmployeeAsync(Employee employee);
    }

    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public EmployeeRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Employee>> GetEmployeesAsync(string cafeName)
        {
            // Query to get all employees, optionally filtered by café
            var query = _dbContext.Employees
                .Include(e => e.Cafe) // Eager load the Cafe for each employee
                .AsQueryable();

            // If a café is provided, filter by café name
            if (!string.IsNullOrEmpty(cafeName))
            {
                query = query.Where(e =>e.Cafe.Name== cafeName);
            }

            return await query.ToListAsync();
        }

        public async Task AddEmployeeAsync(Employee employee)
        {
            // Add the employee to the database
            await _dbContext.Employees.AddAsync(employee);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Employee> GetEmployeeByIdAsync(string employeeId)
        {
            return await _dbContext.Employees.FirstAsync(e => e.Id == employeeId);
        }

        public async Task UpdateEmployeeAsync(Employee employee)
        {
            _dbContext.Employees.Update(employee);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteEmployeeAsync(Employee employee)
        {
            _dbContext.Employees.Remove(employee);
            await _dbContext.SaveChangesAsync();
        }
    }
}
