using MediatR;

namespace CleanArch.API.Application.Queries.EmployeeQueries
{
    public class UpdateEmployeeQuery : IRequest<bool>
    {
        public required string Id { get; set; }
        public required string Name { get; set; }
        public required string EmailAddress { get; set; }
        public required string PhoneNumber { get; set; }
        public required string Gender { get; set; }
        public DateTime StartDate { get; set; }
        public Guid CafeId { get; set; } 
    }
}
