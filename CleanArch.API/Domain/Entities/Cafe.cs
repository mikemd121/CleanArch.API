using System.ComponentModel.DataAnnotations;

public class Cafe
{

    [Required]
    public Guid CafeId { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Description { get; set; }

    public string? Logo { get; set; }

    [Required]
    public string Location { get; set; }


    // Navigation property to employees
    public ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
