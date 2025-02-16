using Microsoft.EntityFrameworkCore;


public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<Cafe> Cafes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        modelBuilder.Entity<Cafe>()
    .HasKey(c => c.CafeId);  // Set 'Id' as the primary key for the Cafe table

        // Configure the primary key for the Employee table
        modelBuilder.Entity<Employee>()
            .HasKey(e => e.Id);  // Set 'Id' as the primary key for the Employee table
    }



    public static void SeedSampleData(ApplicationDbContext context)
    {
        if (!context.Cafes.Any())  // Check if there are any cafes, if not, seed data
        {
            var cafe1 = new Cafe
            {
                CafeId = Guid.NewGuid(),
                Name = "Cafe Mocha",
                Description = "A cozy place to enjoy coffee and cake.",
                Location = "Downtown",
                Logo = "logo1.png",
                Employees = new List<Employee>
                {
                    new Employee
                    {
                        Id = "UI1234567",
                        Name = "John Doe",
                        EmailAddress = "johndoe@example.com",
                        PhoneNumber = "91234567",
                        Gender = "Male",
                        StartDate = DateTime.Now.AddYears(-2)
                    },
                    new Employee
                    {
                        Id = "UI7654321",
                        Name = "Jane Smith",
                        EmailAddress = "janesmith@example.com",
                        PhoneNumber = "91876543",
                        Gender = "Female",
                        StartDate = DateTime.Now.AddMonths(-6)
                    }
                }
            };

            var cafe2 = new Cafe
            {
                CafeId = Guid.NewGuid(),
                Name = "Brewed Awakening",
                Description = "A modern coffee shop serving artisan coffee.",
                Location = "Uptown",
                Logo = "logo2.png",
                Employees = new List<Employee>
                {
                    new Employee
                    {
                        Id = "UI2345678",
                        Name = "Alice Green",
                        EmailAddress = "alicegreen@example.com",
                        PhoneNumber = "90876543",
                        Gender = "Female",
                        StartDate = DateTime.Now.AddMonths(-1)
                    }
                }
            };

            // Add cafes to the context
            context.Cafes.AddRange(cafe1, cafe2);
            context.SaveChanges();
        }
    }
    }
