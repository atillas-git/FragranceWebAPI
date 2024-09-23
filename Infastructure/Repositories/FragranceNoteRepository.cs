using Domain.Entities;
using Domain.Interfaces;
using Infastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class FragranceNoteRepository : IFragranceNoteRepository
    {
        private readonly FragranceDbContext _context;

        public FragranceNoteRepository(FragranceDbContext context)
        {
            _context = context;
        }

        public async Task<FragranceNote> GetByIdAsync(int id)
        {
            return await _context.FragranceNotes
                .Include(fn => fn.FragranceFragranceNotes)
                .AsNoTracking()
                .FirstOrDefaultAsync(fn => fn.Id == id);
        }

        public async Task<IEnumerable<FragranceNote>> GetAllAsync()
        {
            return await _context.FragranceNotes
                .Include(fn => fn.FragranceFragranceNotes)
                .ToListAsync();
        }

        public async Task AddAsync(FragranceNote fragranceNote)
        {
            var existingNote = await _context.FragranceNotes.FirstOrDefaultAsync(fn => fn.Name == fragranceNote.Name);
            if (existingNote != null)
            {
                return;
            }
            await _context.FragranceNotes.AddAsync(fragranceNote);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(FragranceNote fragranceNote)
        {
            _context.FragranceNotes.Update(fragranceNote);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(FragranceNote fragranceNote)
        {
            _context.FragranceNotes.Remove(fragranceNote);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<FragranceNote>> SearchAsync(string query, int pageNumber = 1, int pageSize = 10)
        {
            return await _context.FragranceNotes
                .Where(fn=>fn.Name.Contains(query,StringComparison.OrdinalIgnoreCase))
                .Skip((pageNumber-1) * pageSize)
                .Take(pageSize)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}

