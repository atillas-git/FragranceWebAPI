using Domain.Entities;
using Domain.Interfaces;
using Infastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infastructure.Repositories
{
    // Infrastructure/Repositories/FragranceRepository.cs
    public class FragranceRepository : IFragranceRepository
    {
        private readonly FragranceDbContext _context;

        public FragranceRepository(FragranceDbContext context)
        {
            _context = context;
        }

        public async Task<Fragrance> GetFragranceByIdAsync(int id)
        {
            return await _context.Fragrances.Include(f => f.FragranceCreators)
                                             .Include(f => f.FragranceFragranceNotes)
                                             .Include(f => f.Brand)
                                             .AsNoTracking()
                                             .FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<IEnumerable<Fragrance>> GetAllFragrancesAsync()
        {
            return await _context.Fragrances.ToListAsync();
        }

        public async Task AddFragranceAsync(Fragrance fragrance)
        {
            var existingFragrance = await _context.Fragrances
                .Include(f => f.Brand)
                .AsNoTracking()
                .FirstOrDefaultAsync(f => f.Name == fragrance.Name && f.Brand.Id == fragrance.BrandId);
            if (existingFragrance != null) {
                return;
            }
            await _context.Fragrances.AddAsync(fragrance);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteFragranceAsync(Fragrance fragrance)
        {
            _context.Fragrances.Remove(fragrance);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateFragranceAsync(Fragrance fragrance)
        {
            _context.Update(fragrance);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Fragrance>> SearchFragranceAsync(string query, int pageNumber = 1, int pageSize = 10)
        {
            return await _context.Fragrances
                .Include(f => f.FragranceCreators)
                .Include(f => f.FragranceFragranceNotes)
                .Include(f => f.Ratings)
                .Include(f => f.Comments)
                .Where(f => f.Name.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                            f.FragranceCreators.Any(fc => fc.Creator.Name.Contains(query, StringComparison.OrdinalIgnoreCase)) ||
                            f.FragranceFragranceNotes.Any(fn => fn.FragranceNote.Name.Contains(query, StringComparison.OrdinalIgnoreCase)))
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .AsNoTracking()
                .OrderBy(f=>f.Name)
                .ToListAsync();
        }
    }

}
