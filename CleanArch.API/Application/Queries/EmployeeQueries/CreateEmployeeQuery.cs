using MediatR;
using System.ComponentModel.DataAnnotations;

namespace CleanArch.API.Application.Queries.EmployeeQueries
{
    public class CreateEmployeeQuery : IRequest<string> 
    {
        [Required(ErrorMessage = "Employee name is required.")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "Email address is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public required string EmailAddress { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [RegularExpression(@"^[89]\d{7}$", ErrorMessage = "Phone number must start with 8 or 9 and have 8 digits.")]
        public required string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Gender is required.")]
        public required string Gender { get; set; }

        [Required(ErrorMessage = "Start date is required.")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Associated café is required.")]
        public Guid CafeId { get; set; }
    }
}
