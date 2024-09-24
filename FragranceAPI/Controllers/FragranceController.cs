using Application.Dtos.Fragrance;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FragranceAPI.Controllers
{
    [Route("api/fragrances")]
    [ApiController]
    public class FragranceController : Controller
    {
        private readonly IFragranceService _fragranceService;

        public FragranceController(IFragranceService fragranceService)
        {
            _fragranceService = fragranceService;
        }
        [HttpGet("admin")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> GetAllFragrancesAsync()
        {
            var fragrances = await _fragranceService.GetAllFragrancesAsync();
            return Ok(fragrances);
        }
        [HttpPost("admin")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> AddFragranceAsync([FromBody] FragranceCreateUpdateDto dto)
        {
            await _fragranceService.AddFragranceAsync(dto);
            return Ok();
        }

        [HttpPut("admin/{id}")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> UpdateFragranceAsync(int id,[FromBody] FragranceCreateUpdateDto dto)
        {
            await _fragranceService.UpdateFragranceAsync(id,dto);
            return Ok();
        }

        [HttpDelete("admin/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteFragranceAsync(int id)
        {
            await _fragranceService.DeleteFragranceAsync(id);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFragranceByIdAsync(int id)
        {
            var fragrance = await _fragranceService.GetFragranceAsync(id);
            return Ok(fragrance);
        }
        [HttpGet("search")]
        public async Task<IActionResult> SearchFragrancesAsync(string query = "",int pageNumber = 1,int pageSize = 10)
        {
            var fragrances = await _fragranceService.SearchFragranceAsync(query,pageNumber,pageSize);
            if(fragrances == null) {
                return NotFound();
            }
            return Ok(fragrances);
        }
    }
}
