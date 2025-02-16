using System.ComponentModel.DataAnnotations;

public class Cafe
{

    [Required]
    public Guid CafeId { get; set; }

    [Required]
    public required string Name { get; set; }

    [Required]
    public required string Description { get; set; }

    public byte[]? Logo { get; set; }

    [Required]
    public required string Location { get; set; }

    public ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
