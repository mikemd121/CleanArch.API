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
            // Fetch the cafe by its ID
            var cafe = await _cafeRepository.GetCafeByIdAsync(request.CafeId);
            if (cafe == null)
            {
                return false; // Cafe not found
            }

            // Update the properties of the cafe
            cafe.Name = request.Name;
            cafe.Description = request.Description;
            cafe.Logo = request.Logo;
            cafe.Location = request.Location;

            // Save the changes to the database
            await _cafeRepository.UpdateCafeAsync(cafe);

            return true; // Successfully updated
        }
    }
}
