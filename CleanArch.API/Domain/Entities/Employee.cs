using System;
using System.ComponentModel.DataAnnotations;

public class Employee
{
    [Required]
    [RegularExpression(@"^UI\d{7}$", ErrorMessage = "ID must be in the format 'UIXXXXXXX' where X is alphanumeric.")]
    public required string Id { get; set; }

    [Required]
    public required string Name { get; set; }

    [Required]
    [EmailAddress(ErrorMessage = "Invalid email address.")]
    public required string EmailAddress { get; set; }

    [Required]
    [RegularExpression(@"^[89]\d{7}$", ErrorMessage = "Phone number must start with 8 or 9 and contain exactly 8 digits.")]
    public required string PhoneNumber { get; set; }

    [Required]
    [RegularExpression(@"^(Male|Female)$", ErrorMessage = "Gender must be either 'Male' or 'Female'.")]
    public required string Gender { get; set; }

    [Required]
    public DateTime StartDate { get; set; }

    public Guid CafeId { get; set; } 
    public Cafe Cafe { get; set; }
}
