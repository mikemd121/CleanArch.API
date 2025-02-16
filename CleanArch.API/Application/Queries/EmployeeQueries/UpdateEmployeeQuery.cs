using MediatR;

namespace CleanArch.API.Application.Queries.EmployeeQueries
{
    public class UpdateEmployeeQuery : IRequest<bool>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public DateTime StartDate { get; set; }
        public Guid CafeId { get; set; } // This links the employee to a specific cafe
    }
}
