using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IRatingRepository
    {
        Task<Rating> GetByIdAsync(int id);
        Task<IEnumerable<Rating>> GetAllByFragranceIdAsync(int fragranceId);
        Task<IEnumerable<Rating>> GetAllByUserIdAsync(int userId);
        Task AddAsync(Rating rating);
        Task UpdateAsync(Rating rating);
        Task DeleteAsync(int id);
    }
}
