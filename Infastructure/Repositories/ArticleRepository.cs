using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Domain.Interfaces;
using Infastructure.Context;

namespace Infastructure.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly FragranceDbContext _context;

        public ArticleRepository(FragranceDbContext context)
        {
            _context = context;
        }

        public async Task<Article> GetArticleByIdAsync(int id)
        {
            return await _context.Articles
                .Include(a => a.RelatedFragrances)
                .Include(a => a.RelatedBrands)
                .Include(a => a.RelatedCreators)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<Article>> GetAllArticlesAsync()
        {
            return await _context.Articles
                .Include(a => a.RelatedFragrances)
                .Include(a => a.RelatedBrands)
                .Include(a => a.RelatedCreators)
                .ToListAsync();
        }

        public async Task<IEnumerable<Article>> GetArticlesByAuthorAsync(string author)
        {
            return await _context.Articles
                .Where(a => a.Author == author)
                .Include(a => a.RelatedFragrances)
                .Include(a => a.RelatedBrands)
                .Include(a => a.RelatedCreators)
                .ToListAsync();
        }

        public async Task AddArticleAsync(Article article)
        {
            await _context.Articles.AddAsync(article);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateArticleAsync(Article article)
        {
            _context.Articles.Update(article);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteArticleAsync(Article article)
        {
            _context.Articles.Remove(article);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Article>> GetArticlesByPublishedDateAsync(DateTime publishedDate)
        {
            return await _context.Articles
                .Where(a => a.PublishedDate.Date == publishedDate.Date)
                .Include(a => a.RelatedFragrances)
                .Include(a => a.RelatedBrands)
                .Include(a => a.RelatedCreators)
                .ToListAsync();
        }
    }
}

