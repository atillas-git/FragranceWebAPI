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

        public async Task<FragranceNote> GetFragranceNoteByIdAsync(int id)
        {
            return await _context.FragranceNotes
                .Include(fn => fn.FragranceFragranceNotes)
                .AsNoTracking()
                .FirstOrDefaultAsync(fn => fn.Id == id);
        }

        public async Task<IEnumerable<FragranceNote>> GetAllFragranceNotesAsync()
        {
            return await _context.FragranceNotes
                .Include(fn => fn.FragranceFragranceNotes)
                .ToListAsync();
        }

        public async Task AddFragranceNoteAsync(FragranceNote fragranceNote)
        {
            var existingNote = await _context.FragranceNotes.FirstOrDefaultAsync(fn => fn.Name == fragranceNote.Name);
            if (existingNote != null)
            {
                return;
            }
            await _context.FragranceNotes.AddAsync(fragranceNote);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateFragranceNoteAsync(FragranceNote fragranceNote)
        {
            _context.FragranceNotes.Update(fragranceNote);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteFragranceNoteAsync(FragranceNote fragranceNote)
        {
            _context.FragranceNotes.Remove(fragranceNote);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<FragranceNote>> SearchFragranceNotesAsync(string query, int pageNumber = 1, int pageSize = 10)
        {
            var fragranceNoteQuery = _context.FragranceNotes;
            if (!string.IsNullOrWhiteSpace(query))
            {
                fragranceNoteQuery.Where(fn => fn.Name.ToLower().Contains(query.ToLower()));
            }
            return await fragranceNoteQuery
                .Skip((pageNumber-1) * pageSize)
                .Take(pageSize)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}

