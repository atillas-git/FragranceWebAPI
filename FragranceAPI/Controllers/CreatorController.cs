using Application.Dtos.Creator;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FragranceAPI.Controllers
{
    [Route("api/creators")]
    public class CreatorController : Controller
    {
        private ICreatorService _creatorService;

        public CreatorController(ICreatorService creatorService)
        {
            _creatorService = creatorService;
        }

        [HttpGet("admin")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> GetAllCreatorsAsync()
        {
            var creators = await _creatorService.GetAllCreatorsAsync();
            return Ok(creators);
        }

        [HttpPost("admin")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> AddCreatorAsync([FromBody] CreatorCreateUpdateDto creatorCreateUpdateDto)
        {
            await _creatorService.AddCreatorAsync(creatorCreateUpdateDto);
            return Ok();
        }

        [HttpPut("admin/{id}")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> UpdateCreatorAsync(int id,[FromBody] CreatorCreateUpdateDto creatorCreateUpdateDto)
        {
            await _creatorService.UpdateCreatorAsync(id, creatorCreateUpdateDto);
            return Ok();
        }

        [HttpDelete("admin/{id}")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> DeleteCreatorAsync(int id)
        {
            await _creatorService.DeleteCreatorAsync(id);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCreatorById(int id)
        {
            var creator = await _creatorService.GetCreatorByIdAsync(id);
            return Ok(creator);
        }
        [HttpGet("search")]
        public async Task<IActionResult> SearchCreatorsAsync(string query = "",int pageNumber=1,int pageSize=10)
        {
            var creators = await _creatorService.SearchCreatorsAsync(query,pageNumber,pageSize);
            return Ok(creators);
        }
    }
}
