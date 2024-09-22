using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infastructure.Repositories
{
    using Domain.Entities;
    using Domain.Interfaces;
    using Infastructure.Context;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    namespace Infrastructure.Repositories
    {
        public class CreatorRepository : ICreatorRepository
        {
            private readonly FragranceDbContext _context;

            public CreatorRepository(FragranceDbContext context)
            {
                _context = context;
            }

            public async Task<Creator> GetByIdAsync(int id)
            {
                return await _context.Creators
                    .Include(c => c.FragranceCreators)
                    .ThenInclude(fc => fc.Fragrance)
                    .FirstOrDefaultAsync(c => c.Id == id);
            }

            public async Task<IEnumerable<Creator>> GetAllAsync()
            {
                return await _context.Creators
                    .Include(c => c.FragranceCreators)
                    .ThenInclude(fc => fc.Fragrance)
                    .ToListAsync();
            }

            public async Task AddAsync(Creator creator)
            {
                await _context.Creators.AddAsync(creator);
                await _context.SaveChangesAsync();
            }

            public async Task UpdateAsync(Creator creator)
            {
                _context.Creators.Update(creator);
                await _context.SaveChangesAsync();
            }

            public async Task DeleteAsync(int id)
            {
                var creator = await _context.Creators.FindAsync(id);
                if (creator != null)
                {
                    _context.Creators.Remove(creator);
                    await _context.SaveChangesAsync();
                }
            }

            public async Task<IEnumerable<Creator>> SearchAsync(string query, int pageNumber = 1, int pageSize = 10)
            {
                var creators = await _context.Creators
                    .Where(c=>c.Name.Contains(query,StringComparison.OrdinalIgnoreCase))
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .AsNoTracking()
                    .ToListAsync();
                return creators;
            }
        }
    }

}
