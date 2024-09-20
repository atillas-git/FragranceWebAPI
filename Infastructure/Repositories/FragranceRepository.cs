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
                                             .FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<IEnumerable<Fragrance>> GetAllFragrancesAsync()
        {
            return await _context.Fragrances.ToListAsync();
        }

        public async Task AddFragranceAsync(Fragrance fragrance)
        {
            await _context.Fragrances.AddAsync(fragrance);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteFragranceAsync(int id)
        {
            var fragrance = await _context.Fragrances.FindAsync(id);

            if (fragrance != null)
            {
                _context.Fragrances.Remove(fragrance);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateFragranceAsync(int id, Fragrance fragrance)
        {
            var fragranceToUpdate = await _context.Fragrances.FindAsync(id);

            if (fragranceToUpdate != null)
            {
                fragranceToUpdate.Name = fragrance.Name;
                fragranceToUpdate.Gender = fragrance.Gender;
                fragranceToUpdate.PictureUrl = fragrance.PictureUrl;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Fragrance>> SearchAsync(string query)
        {
            return await _context.Fragrances
                .Include(f => f.FragranceCreators)
                .Include(f => f.FragranceFragranceNotes)
                .Include(f => f.Ratings)
                .Include(f => f.Comments)
                .Where(f => f.Name.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                            f.FragranceCreators.Any(fc => fc.Creator.Name.Contains(query, StringComparison.OrdinalIgnoreCase)) ||
                            f.FragranceFragranceNotes.Any(fn => fn.FragranceNote.Name.Contains(query, StringComparison.OrdinalIgnoreCase)))
                .ToListAsync();
        }
    }

}
