using CleanArch.API.Infrastructure.Repositories;
using MediatR;

namespace CleanArch.API.Application.Queries.CafeQueries
{
  
        public class CreateCafeQueryHandler : IRequestHandler<CreateCafeQuery, Guid>
        {
            private readonly ICafeRepository _cafeRepository;

            public CreateCafeQueryHandler(ICafeRepository cafeRepository)
            {
                _cafeRepository = cafeRepository;
            }

            public async Task<Guid> Handle(CreateCafeQuery request, CancellationToken cancellationToken)
            {
                var cafe = new Cafe
                {
                    CafeId = Guid.NewGuid(),  // Generate a new GUID for the cafe
                    Name = request.Name,
                    Description = request.Description,
                    Location = request.Location,
                    Logo = request.Logo
                };

                await _cafeRepository.AddCafeAsync(cafe);

                return cafe.CafeId;  // Return the GUID of the newly created cafe
            }
        }
    
}
