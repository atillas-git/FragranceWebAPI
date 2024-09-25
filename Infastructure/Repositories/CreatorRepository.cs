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

            public async Task<Creator> GetCreatorByIdAsync(int id)
            {
                return await _context.Creators
                    .Include(c => c.FragranceCreators)
                    .ThenInclude(fc => fc.Fragrance)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(c => c.Id == id);
            }

            public async Task<IEnumerable<Creator>> GetAllCreatorsAsync()
            {
                return await _context.Creators
                    .Include(c => c.FragranceCreators)
                    .ToListAsync();
            }

            public async Task AddCreatorAsync(Creator creator)
            {
                await _context.Creators.AddAsync(creator);
                await _context.SaveChangesAsync();
            }

            public async Task UpdateCreatorAsync(Creator creator)
            {
                _context.Creators.Update(creator);
                await _context.SaveChangesAsync();
            }

            public async Task DeleteCreatorAsync(Creator creator)
            {
                _context.Creators.Remove(creator);
                await _context.SaveChangesAsync();
            }

            public async Task<IEnumerable<Creator>> SearchCreatorsAsync(string query, int pageNumber = 1, int pageSize = 10)
            {
                var creatorSearchQuery = _context.Creators;
                if (!string.IsNullOrEmpty(query))
                {
                    var queryLower = query.ToLower();
                    creatorSearchQuery.Where(c => c.Name.ToLower().Contains(query));

                }
                var creators = await creatorSearchQuery
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .AsNoTracking()
                    .ToListAsync();

                return creators;
            }
        }
    }

}
