using Microsoft.AspNetCore.Mvc;
using Application.Dtos.Rating;
using Application.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Exceptions;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Application.Controllers
{
    [ApiController]
    [Route("api/ratings")]
    public class RatingsController : ControllerBase
    {
        private readonly IRatingService _ratingService;

        public RatingsController(IRatingService ratingService)
        {
            _ratingService = ratingService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRatingByIdAsync(int id)
        {
            var rating = await _ratingService.GetRatingByIdAsync(id);
            return Ok(rating);
        }

        [HttpGet("fragrance/{fragranceId}")]
        public async Task<IActionResult> GetRatingsByFragranceIdAsync(int fragranceId)
        {
            var ratings = await _ratingService.GetRatingsByFragranceIdAsync(fragranceId);
            return Ok(ratings);
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetRatingsByUserIdAsync(int userId)
        {
            var ratings = await _ratingService.GetRatingsByUserIdAsync(userId);
            return Ok(ratings);
        }

        [HttpPost("/shared")]
        [Authorize(Roles ="Admin,User")]
        public async Task<IActionResult> AddRatingAsync([FromBody] RatingCreateUpdateDto ratingDto)
        {
            await _ratingService.AddRatingAsync(ratingDto);
            return Ok();
        }

        [HttpPut("shared/{userId}/{ratingId}")]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> UpdateRatingAsync(int userId,int ratingId, [FromBody] RatingCreateUpdateDto ratingDto)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim != null && userId.ToString() != userIdClaim.Value && User.IsInRole("User")) {
                return Forbid();
            }
            await _ratingService.UpdateRatingAsync(ratingId, ratingDto);
            return NoContent();
        }

        [HttpDelete("shared/{userId}/{ratingId}")]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> DeleteRatingAsync(int userId,int ratingId)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim != null && userId.ToString() != userIdClaim.Value && User.IsInRole("User"))
            {
                return Forbid();
            }
            await _ratingService.DeleteRatingAsync(ratingId);
            return NoContent();
        }
    }
}

