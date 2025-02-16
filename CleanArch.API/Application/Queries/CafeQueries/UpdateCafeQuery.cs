using MediatR;

namespace CleanArch.API.Application.Queries.CafeQueries
{
    public class UpdateCafeQuery : IRequest<bool>
    {
        public Guid CafeId { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public IFormFile? Logo { get; set; }
        public required string Location { get; set; }
    }
}
