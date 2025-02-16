namespace CleanArch.API.Domain.DTOs
{
    public class CafeDTO
    {
        public Guid Id { get; set; } 
        public required string Name { get; set; }
        public required string Description { get; set; } 
        public int Employees { get; set; }
        public string? Logo { get; set; } 
        public required string Location { get; set; }
    }
}
