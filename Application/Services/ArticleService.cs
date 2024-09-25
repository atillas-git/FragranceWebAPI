using AutoMapper;
using Application.Dtos.Article;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Messages;
using Application.Exceptions;

namespace Application.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IMapper _mapper;

        public ArticleService(IArticleRepository articleRepository, IMapper mapper)
        {
            _articleRepository = articleRepository;
            _mapper = mapper;
        }

        public async Task<ArticleDto> GetArticleByIdAsync(int id)
        {
            var article = await _articleRepository.GetArticleByIdAsync(id);
            if (article == null)
            {
                throw new KeyNotFoundException(ResponseMessages.Article_ArticleDoesNotExist);
            }
            return _mapper.Map<ArticleDto>(article);
        }

        public async Task<IEnumerable<ArticleDto>> GetAllArticlesAsync()
        {
            var articles = await _articleRepository.GetAllArticlesAsync();
            return _mapper.Map<IEnumerable<ArticleDto>>(articles);
        }

        public async Task<IEnumerable<ArticleDto>> GetArticlesByAuthorAsync(string author)
        {
            if (string.IsNullOrWhiteSpace(author))
            {
                throw new AppException(ResponseMessages.Shared_PleaseFillTheRequiredFields);
            }
            var articles = await _articleRepository.GetArticlesByAuthorAsync(author);
            return _mapper.Map<IEnumerable<ArticleDto>>(articles);
        }

        public async Task AddArticleAsync(ArticleCreateUpdateDto articleDto)
        {
            ValidateArticleDto(articleDto);

            var article = _mapper.Map<Article>(articleDto);

            await _articleRepository.AddArticleAsync(article);
        }

        public async Task UpdateArticleAsync(int id, ArticleCreateUpdateDto articleDto)
        {
            ValidateArticleDto(articleDto);

            var existingArticle = await _articleRepository.GetArticleByIdAsync(id);
            if (existingArticle == null)
            {
                throw new KeyNotFoundException(ResponseMessages.Article_ArticleDoesNotExist);
            }

            _mapper.Map(articleDto, existingArticle); 
            await _articleRepository.UpdateArticleAsync(existingArticle);
        }

        public async Task DeleteArticleAsync(int id)
        {
            var article = await _articleRepository.GetArticleByIdAsync(id);
            if (article == null)
            {
                throw new KeyNotFoundException(ResponseMessages.Article_ArticleDoesNotExist);
            }
            await _articleRepository.DeleteArticleAsync(article);
        }

        public async Task<IEnumerable<ArticleDto>> GetArticlesByPublishedDateAsync(DateTime publishedDate)
        {
            var articles = await _articleRepository.GetArticlesByPublishedDateAsync(publishedDate);
            return _mapper.Map<IEnumerable<ArticleDto>>(articles);
        }
        private void ValidateArticleDto(ArticleCreateUpdateDto articleDto)
        {
            if (string.IsNullOrWhiteSpace(articleDto.Title) ||
                string.IsNullOrWhiteSpace(articleDto.Content) ||
                string.IsNullOrWhiteSpace(articleDto.Author) ||
                !articleDto.PublishedDate.HasValue)
            {
                throw new AppException(ResponseMessages.Shared_PleaseFillTheRequiredFields);
            }
        }
    }
}
