﻿using Application.Dtos.Fragrance;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FragranceAPI.Controllers
{
    [Route("api/fragrance")]
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
        public async Task<IActionResult> GetAllFragrances()
        {
            var fragrances = await _fragranceService.GetAllFragrancesAsync();
            return Ok(fragrances);
        }
        [HttpPost("admin")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> AddFragrance(FragranceCreateUpdateDto dto)
        {
            await _fragranceService.AddFragranceAsync(dto);
            return Ok();
        }

        [HttpPut("admin/{id}")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> UpdateFragrance(int id,[FromBody] FragranceCreateUpdateDto dto)
        {
            await _fragranceService.UpdateFragranceAsync(id,dto);
            return Ok();
        }

        [HttpDelete("admin/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteFragrance(int id)
        {
            await _fragranceService.DeleteFragranceAsync(id);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFragranceById(int id)
        {
            var fragrance = await _fragranceService.GetFragranceAsync(id);
            return Ok(fragrance);
        }
        [HttpGet("search")]
        public async Task<IActionResult> SearchFragrances(string query,int pageNumber = 1,int pageSize = 10)
        {
            var fragrances = await _fragranceService.SearchFragranceAsync(query,pageNumber,pageSize);
            if(fragrances == null) {
                return NotFound();
            }
            return Ok(fragrances);
        }
    }
}
