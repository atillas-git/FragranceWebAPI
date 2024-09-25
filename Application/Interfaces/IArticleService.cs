using Application.Dtos.Article;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IArticleService
    {
        Task<ArticleDto> GetArticleByIdAsync(int id);
        Task<IEnumerable<ArticleDto>> GetAllArticlesAsync();
        Task<IEnumerable<ArticleDto>> GetArticlesByAuthorAsync(string author);
        Task AddArticleAsync(ArticleCreateUpdateDto articleDto);
        Task UpdateArticleAsync(int id, ArticleCreateUpdateDto articleDto);
        Task DeleteArticleAsync(int id);
        Task<IEnumerable<ArticleDto>> GetArticlesByPublishedDateAsync(DateTime publishedDate);
    }
}

