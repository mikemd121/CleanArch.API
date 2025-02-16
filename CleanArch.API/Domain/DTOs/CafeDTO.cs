namespace CleanArch.API.Domain.DTOs
{
    public class CafeDTO
    {
        public Guid Id { get; set; } // Unique identifier of the cafe (UUID)
        public string Name { get; set; } // Name of the cafe
        public string Description { get; set; } // Short description of the cafe
        public int Employees { get; set; } // Number of employees in the cafe
        public string Logo { get; set; } // Optional logo URL of the cafe (can be null)
        public string Location { get; set; } // Location of the cafe
    }
}
