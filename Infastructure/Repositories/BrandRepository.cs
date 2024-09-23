﻿using Domain.Entities;
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
    public class BrandRepository : IBrandRepository
    {
        private readonly FragranceDbContext _context;

        public BrandRepository(FragranceDbContext context)
        {
            _context = context;
        }

        public async Task AddBrandAsync(Brand brand)
        {
            _context.Brands.Add(brand);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBrandAsync(Brand brand)
        {
            _context.Remove(brand);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Brand>> GetAllBrandsAsync()
        {
            return await _context.Brands.ToListAsync();
        }

        public async Task<Brand> GetBrandByIdAsync(int id)
        {
            return await _context.Brands.FindAsync(id);
        }

        public async Task<Brand> GetBrandByNameAsync(string name)
        {
            return await _context.Brands.FirstOrDefaultAsync(b => b.Name == name);
        }

        public async Task<IEnumerable<Brand>> SearchBrandAsync(string query, int pageNumber = 1, int pageSize=10)
        {
            var brands = await _context.Brands.Include(b=>b.Fragrances)
                .Include(b=>b.RelatedArticles)
                .AsNoTracking()
                .Where(b=>b.Name.Contains(query,StringComparison.OrdinalIgnoreCase) 
                    && b.Country.Contains(query,StringComparison.OrdinalIgnoreCase)
                    && b.WebsiteUrl.Contains(query,StringComparison.OrdinalIgnoreCase))
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            return brands;
        }

        public async Task UpdateBrandAsync(Brand brand)
        {
            _context.Update(brand);
            await _context.SaveChangesAsync();
        }
    }
}
