using MediatR;

namespace CleanArch.API.Application.Queries.CafeQueries
{
    public class DeleteCafeQuery : IRequest<bool>
    {
        public Guid CafeId { get; set; }
    }
}
