using System.ComponentModel.DataAnnotations;
using MediatR;
public class CreateCafeQuery : IRequest<Guid>
{
    [Required(ErrorMessage = "Cafe name is required.")]
    public required string Name { get; set; }

    [Required(ErrorMessage = "Cafe description is required.")]
    public required string Description { get; set; }

    [Required(ErrorMessage = "Cafe location is required.")]
    public required string Location { get; set; }

    // Optional field, so no [Required] attribute
    public string Logo { get; set; }
}


