using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IArticleRepository
    {
        Task<Article> GetArticleByIdAsync(int id);
        Task<IEnumerable<Article>> GetAllArticlesAsync();
        Task<IEnumerable<Article>> GetArticlesByAuthorAsync(string author);
        Task AddArticleAsync(Article article);
        Task UpdateArticleAsync(Article article);
        Task DeleteArticleAsync(Article article);
        Task<IEnumerable<Article>> GetArticlesByPublishedDateAsync(DateTime publishedDate);
    }
}
