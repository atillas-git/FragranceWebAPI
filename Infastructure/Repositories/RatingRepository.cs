using Domain.Entities;
using Domain.Interfaces;
using Infastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class RatingRepository : IRatingRepository
    {
        private readonly FragranceDbContext _context;

        public RatingRepository(FragranceDbContext context)
        {
            _context = context;
        }

        public async Task<Rating> GetByIdAsync(int id)
        {
            return await _context.Ratings
                .Include(r => r.User)
                .Include(r => r.Fragrance)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<IEnumerable<Rating>> GetAllByFragranceIdAsync(int fragranceId)
        {
            return await _context.Ratings
                .Where(r => r.FragranceId == fragranceId)
                .Include(r => r.User)
                .ToListAsync();
        }

        public async Task<IEnumerable<Rating>> GetAllByUserIdAsync(int userId)
        {
            return await _context.Ratings
                .Where(r => r.UserId == userId)
                .Include(r => r.Fragrance)
                .ToListAsync();
        }

        public async Task AddAsync(Rating rating)
        {
            await _context.Ratings.AddAsync(rating);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Rating rating)
        {
            _context.Ratings.Update(rating);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var rating = await _context.Ratings.FindAsync(id);
            if (rating != null)
            {
                _context.Ratings.Remove(rating);
                await _context.SaveChangesAsync();
            }
        }
    }
}

