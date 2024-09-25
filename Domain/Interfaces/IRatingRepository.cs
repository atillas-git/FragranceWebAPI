using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IRatingRepository
    {
        Task<Rating> GetRatingByIdAsync(int id);
        Task<IEnumerable<Rating>> GetAllRatingsByFragranceIdAsync(int fragranceId);
        Task<IEnumerable<Rating>> GetAllRatingsByUserIdAsync(int userId);
        Task AddRatingAsync(Rating rating);
        Task UpdateRatingAsync(Rating rating);
        Task DeleteRatingAsync(Rating rating);
    }
}
