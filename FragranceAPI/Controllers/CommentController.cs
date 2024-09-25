using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Application.Dtos.Comment;
using Application.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Security.Claims;
using Application.Exceptions;

namespace Application.Controllers
{
    [ApiController]
    [Route("api/comments")]
    [Authorize] // Ensure the user is authenticated
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCommentById(int id)
        {
            var comment = await _commentService.GetCommentByIdAsync(id);
            return Ok(comment);
        }

        [HttpGet("fragrance/{fragranceId}")]
        public async Task<IActionResult> GetCommentsByFragranceId(int fragranceId)
        {
            var comments = await _commentService.GetCommentsByFragranceIdAsync(fragranceId);
            return Ok(comments);
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetCommentsByUserId(int userId)
        {
            var comments = await _commentService.GetCommentsByUserIdAsync(userId);
            return Ok(comments);
        }

        [HttpPost("shared/{userId}")]
        [Authorize(Roles ="Admin,User")]
        public async Task<IActionResult> AddComment(int userId,[FromBody] CommentCreateUpdateDto commentDto)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim != null && userId.ToString() != userIdClaim.Value && User.IsInRole("User"))
            {
                return Forbid();
            }
            await _commentService.AddCommentAsync(commentDto);
            return Ok();
        }

        [HttpPut("shared/{userId}/{commentId}")]
        [Authorize(Roles = "Admin,User")] // Allow both Admin and User roles to update comments
        public async Task<IActionResult> UpdateComment(int userId,int commentId, [FromBody] CommentCreateUpdateDto commentDto)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim != null && userId.ToString() != userIdClaim.Value && User.IsInRole("User"))
            {
                return Forbid();
            }
            await _commentService.UpdateCommentAsync(commentId, commentDto);
            return Ok();
        }

        [HttpDelete("shared/{userId}/{commentId}")]
        [Authorize(Roles = "Admin,User")] // Only allow Admin role to delete comments
        public async Task<IActionResult> DeleteComment(int userId,int commentId)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim != null && userId.ToString() != userIdClaim.Value && User.IsInRole("User"))
            {
                return Forbid();
            }
            await _commentService.DeleteCommentAsync(commentId);
            return Ok();
        }
    }
}
