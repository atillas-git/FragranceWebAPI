using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Application.Dtos.Article;
using Application.Interfaces;
using Application.Exceptions;

namespace Application.Controllers
{
    [ApiController]
    [Route("api/articles")]
    [Authorize] // Ensure that user is authenticated
    public class ArticleController : ControllerBase
    {
        private readonly IArticleService _articleService;

        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetArticleById(int id)
        {
            var article = await _articleService.GetArticleByIdAsync(id);
            return Ok(article);
        }

        [HttpGet("admin")]
        public async Task<IActionResult> GetAllArticles()
        {
            var articles = await _articleService.GetAllArticlesAsync();
            return Ok(articles);
        }

        // GET: api/articles/author/{author}
        [HttpGet("author/{author}")]
        public async Task<IActionResult> GetArticlesByAuthor(string author)
        {
            var articles = await _articleService.GetArticlesByAuthorAsync(author);
            return Ok(articles);
        }

        [HttpGet("published/{publishedDate}")]
        public async Task<IActionResult> GetArticlesByPublishedDate(DateTime publishedDate)
        {
            var articles = await _articleService.GetArticlesByPublishedDateAsync(publishedDate);
            return Ok(articles);
        }

        [HttpPost("shared")]
        [Authorize(Roles = "Admin,Editor")] // 
        public async Task<IActionResult> AddArticle([FromBody] ArticleCreateUpdateDto articleDto)
        {
            await _articleService.AddArticleAsync(articleDto);
            return Ok();
        }

        [HttpPut("shared/{id}")]
        [Authorize(Roles = "Admin,Editor")]
        public async Task<IActionResult> UpdateArticle(int id, [FromBody] ArticleCreateUpdateDto articleDto)
        {
            await _articleService.UpdateArticleAsync(id, articleDto);
            return NoContent();
        }

        [HttpDelete("admin/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteArticle(int id)
        {
            await _articleService.DeleteArticleAsync(id);
            return NoContent();
        }
    }
}

