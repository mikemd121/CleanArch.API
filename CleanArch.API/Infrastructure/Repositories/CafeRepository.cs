using Microsoft.EntityFrameworkCore;

namespace CleanArch.API.Infrastructure.Repositories
{
    public interface ICafeRepository
    {
        Task<List<Cafe>> GetCafesAsync();
        Task AddCafeAsync(Cafe cafe);  // New method to add a cafe
        Task<Cafe> GetCafeByIdAsync(Guid cafeId);
        Task UpdateCafeAsync(Cafe cafe);

        Task DeleteCafeAsync(Cafe cafe);
    }

    public class CafeRepository : ICafeRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CafeRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Cafe>> GetCafesAsync()
        {
            // Query to get all cafes with their associated employees
            return await _dbContext.Cafes
                .Include(c => c.Employees)  // Eagerly load employees
                .ToListAsync();  // Fetch all cafes
        }

        public async Task AddCafeAsync(Cafe cafe)
        {
            await _dbContext.Cafes.AddAsync(cafe);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateCafeAsync(Cafe cafe)
        {
            _dbContext.Cafes.Update(cafe);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Cafe> GetCafeByIdAsync(Guid cafeId)
        {
            return await _dbContext.Cafes.FirstAsync(c => c.CafeId == cafeId);
        }

        public async Task DeleteCafeAsync(Cafe cafe)
        {
            _dbContext.Cafes.Remove(cafe);
            await _dbContext.SaveChangesAsync();
        }
    }

}
