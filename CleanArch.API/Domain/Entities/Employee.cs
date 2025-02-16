using System;
using System.ComponentModel.DataAnnotations;

public class Employee
{
    // Required field: Unique employee identifier in the format 'UIXXXXXXX' (alphanumeric)
    [Required]
    [RegularExpression(@"^UI\d{7}$", ErrorMessage = "ID must be in the format 'UIXXXXXXX' where X is alphanumeric.")]
    public string Id { get; set; }

    // Required field: Name of the employee
    [Required]
    public string Name { get; set; }

    // Required field: Email address of the employee (valid email format)
    [Required]
    [EmailAddress(ErrorMessage = "Invalid email address.")]
    public string EmailAddress { get; set; }

    // Required field: Phone number (starts with 8 or 9 and has exactly 8 digits)
    [Required]
    [RegularExpression(@"^[89]\d{7}$", ErrorMessage = "Phone number must start with 8 or 9 and contain exactly 8 digits.")]
    public string PhoneNumber { get; set; }

    // Required field: Gender of the employee (Male/Female)
    [Required]
    [RegularExpression(@"^(Male|Female)$", ErrorMessage = "Gender must be either 'Male' or 'Female'.")]
    public string Gender { get; set; }

    // Start Date when the employee started working at the cafe
    [Required]
    public DateTime StartDate { get; set; }

    // Foreign Key to Cafe
    public Guid CafeId { get; set; }  // Foreign key to the Cafe entity
    public Cafe Cafe { get; set; }  // Navigation property
}
