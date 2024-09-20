using Application.Dtos.Rating;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IRatingService
    {
        Task<RatingDto> GetRatingAsync(int id);  // Retrieve a single rating by ID
        Task<IEnumerable<RatingDto>> GetRatingsByFragranceIdAsync(int fragranceId);  // Retrieve ratings by fragrance ID
        Task<IEnumerable<RatingDto>> GetRatingsByUserIdAsync(int userId);  // Retrieve ratings by user ID
        Task AddRatingAsync(RatingCreateUpdateDto ratingDto);  // Add a new rating
        Task UpdateRatingAsync(int id, RatingCreateUpdateDto ratingDto);  // Update an existing rating
        Task DeleteRatingAsync(int id);  // Delete a rating
    }
}



