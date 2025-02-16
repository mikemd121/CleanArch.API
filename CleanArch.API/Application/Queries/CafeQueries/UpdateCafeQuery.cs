using MediatR;

namespace CleanArch.API.Application.Queries.CafeQueries
{
    public class UpdateCafeQuery : IRequest<bool>
    {
        public Guid CafeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? Logo { get; set; }
        public string Location { get; set; }
    }
}
