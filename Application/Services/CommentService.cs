using AutoMapper;
using Application.Dtos.Comment;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Messages;
using Application.Exceptions;

namespace Application.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;

        public CommentService(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        public async Task<CommentDto> GetCommentAsync(int id)
        {
            var comment = await _commentRepository.GetByIdAsync(id);
            if (comment == null) {
                throw new AppException(ResponseMessages.Comment_CommentDoesNotExists);
            }
            return _mapper.Map<CommentDto>(comment);  // Map entity to DTO
        }

        public async Task<IEnumerable<CommentDto>> GetCommentsByFragranceIdAsync(int fragranceId)
        {
            var comments = await _commentRepository.GetAllByFragranceIdAsync(fragranceId);
            return _mapper.Map<IEnumerable<CommentDto>>(comments);  // Map entities to DTOs
        }

        public async Task<IEnumerable<CommentDto>> GetCommentsByUserIdAsync(int userId)
        {
            var comments = await _commentRepository.GetAllByUserIdAsync(userId);
            return _mapper.Map<IEnumerable<CommentDto>>(comments);  // Map entities to DTOs
        }

        public async Task AddCommentAsync(CommentCreateUpdateDto commentDto)
        {
            if(string.IsNullOrEmpty(commentDto.Content) || commentDto.UserId == 0 || commentDto.FragranceId == 0)
            {
                throw new AppException(ResponseMessages.Shared_PleaseFillTheRequiredFields);
            }
            var comment = _mapper.Map<Comment>(commentDto);  // Map DTO to entity
            await _commentRepository.AddAsync(comment);
        }

        public async Task UpdateCommentAsync(int id, CommentCreateUpdateDto commentDto)
        {
            var comment = await _commentRepository.GetByIdAsync(id);
            if (comment == null)
            {
                throw new AppException(ResponseMessages.Comment_CommentDoesNotExists);
            };

            _mapper.Map(commentDto, comment);  // Map updated DTO to existing entity
            await _commentRepository.UpdateAsync(comment);
        }

        public async Task DeleteCommentAsync(int id)
        {
            var comment = await _commentRepository.GetByIdAsync(id);
            if (comment == null)
            {
                throw new AppException(ResponseMessages.Comment_CommentDoesNotExists);
            }
            await _commentRepository.DeleteAsync(comment);
        }
    }
}


