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
            await _context.FragranceNotes.AddAsync(fragranceNote);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(FragranceNote fragranceNote)
        {
            _context.FragranceNotes.Update(fragranceNote);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var fragranceNote = await _context.FragranceNotes.FindAsync(id);
            if (fragranceNote != null)
            {
                _context.FragranceNotes.Remove(fragranceNote);
                await _context.SaveChangesAsync();
            }
        }
    }
}

