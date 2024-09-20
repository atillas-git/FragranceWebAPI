using Application.Dtos.Comment;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ICommentService
    {
        Task<CommentDto> GetCommentAsync(int id);  // Retrieve a single comment by ID
        Task<IEnumerable<CommentDto>> GetCommentsByFragranceIdAsync(int fragranceId);  // Retrieve comments by fragrance ID
        Task<IEnumerable<CommentDto>> GetCommentsByUserIdAsync(int userId);  // Retrieve comments by user ID
        Task AddCommentAsync(CommentCreateUpdateDto commentDto);  // Add a new comment
        Task UpdateCommentAsync(int id, CommentCreateUpdateDto commentDto);  // Update an existing comment
        Task DeleteCommentAsync(int id);  // Delete a comment
    }
}


