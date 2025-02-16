using CleanArch.API.Infrastructure.Repositories;
using MediatR;

namespace CleanArch.API.Application.Queries.CafeQueries
{
    public class UpdateCafeQueryHandler : IRequestHandler<UpdateCafeQuery, bool>
    {
        private readonly ICafeRepository _cafeRepository;

        public UpdateCafeQueryHandler(ICafeRepository cafeRepository)
        {
            _cafeRepository = cafeRepository;
        }

        public async Task<bool> Handle(UpdateCafeQuery request, CancellationToken cancellationToken)
        {
            var cafe = await _cafeRepository.GetCafeByIdAsync(request.CafeId);
            if (cafe == null)
            {
                return false; 
            }
            byte[]? logoBytes = null;
            if (request.Logo != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await request.Logo.CopyToAsync(memoryStream);
                    logoBytes = memoryStream.ToArray();
                }
            }

            cafe.Name = request.Name;
            cafe.Description = request.Description;
            cafe.Logo = logoBytes;
            cafe.Location = request.Location;
            await _cafeRepository.UpdateCafeAsync(cafe);

            return true;
        }
    }
}
