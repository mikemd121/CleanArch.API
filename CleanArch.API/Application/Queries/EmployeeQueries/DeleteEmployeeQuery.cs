using MediatR;

namespace CleanArch.API.Application.Queries.EmployeeQueries
{
    public class DeleteEmployeeQuery : IRequest<bool>
    {
        public string EmployeeId { get; set; }
    }
}
