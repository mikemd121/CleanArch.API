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

                byte[]? logoBytes = null;
                if (request.Logo != null)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await request.Logo.CopyToAsync(memoryStream);
                        logoBytes = memoryStream.ToArray();
                    }
                }

            var cafe = new Cafe
                {
                    CafeId = Guid.NewGuid(),
                    Name = request.Name,
                    Description = request.Description,
                    Location = request.Location,
                    Logo = logoBytes
            };

                await _cafeRepository.AddCafeAsync(cafe);

                return cafe.CafeId;
            }
        }
    
}
