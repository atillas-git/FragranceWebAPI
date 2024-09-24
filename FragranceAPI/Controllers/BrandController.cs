using Application.Dtos.Brand;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FragranceAPI.Controllers
{
    [Route("/api/brands")]
    public class BrandController : Controller
    {
        private readonly IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;    
        }

        [HttpGet("admin")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> GetAllBrandsAsync()
        {
            var brands = await _brandService.GetAllBrandsAsync();
            return Ok(brands);
        }

        [HttpPost("admin")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> AddBrandAsync([FromBody] BrandCreateUpdateDto brandCreateUpdateDto)
        {
            await _brandService.AddBrandAsync(brandCreateUpdateDto);
            return Ok();
        }

        [HttpPut("admin/{id}")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> UpdateBrandAsync(int id,[FromBody] BrandCreateUpdateDto brandCreateUpdateDto)
        {
            await _brandService.UpdateBrandAsync(id,brandCreateUpdateDto);
            return Ok();
        }

        [HttpDelete("admin/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteBrandAsync(int id)
        {
            await _brandService.DeleteBrandAsync(id);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> SearchBrandsAsync([FromQuery] string query,int pageNumber = 1,int pageSize = 10)
        {
            var brands = await _brandService.SearchBrandAsync(query,pageNumber,pageSize);
            return Ok(brands);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBrandByIdAsync(int id)
        {
            var brand = await _brandService.GetBrandByIdAsync(id);
            return Ok(brand);
        }
    }
}
