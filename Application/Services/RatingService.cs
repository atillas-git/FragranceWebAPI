using AutoMapper;
using Application.Dtos.Rating;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class RatingService : IRatingService
    {
        private readonly IRatingRepository _ratingRepository;
        private readonly IMapper _mapper;

        public RatingService(IRatingRepository ratingRepository, IMapper mapper)
        {
            _ratingRepository = ratingRepository;
            _mapper = mapper;
        }

        public async Task<RatingDto> GetRatingAsync(int id)
        {
            var rating = await _ratingRepository.GetByIdAsync(id);
            return _mapper.Map<RatingDto>(rating);  // Use AutoMapper to map entity to DTO
        }

        public async Task<IEnumerable<RatingDto>> GetRatingsByFragranceIdAsync(int fragranceId)
        {
            var ratings = await _ratingRepository.GetAllByFragranceIdAsync(fragranceId);
            return _mapper.Map<IEnumerable<RatingDto>>(ratings);
        }

        public async Task<IEnumerable<RatingDto>> GetRatingsByUserIdAsync(int userId)
        {
            var ratings = await _ratingRepository.GetAllByUserIdAsync(userId);
            return _mapper.Map<IEnumerable<RatingDto>>(ratings);
        }

        public async Task AddRatingAsync(RatingCreateUpdateDto ratingDto)
        {
            var rating = _mapper.Map<Rating>(ratingDto);  // Map DTO to entity
            await _ratingRepository.AddAsync(rating);
        }

        public async Task UpdateRatingAsync(int id, RatingCreateUpdateDto ratingDto)
        {
            var rating = await _ratingRepository.GetByIdAsync(id);
            if (rating == null) return;

            _mapper.Map(ratingDto, rating);  // Map updated DTO to existing entity
            await _ratingRepository.UpdateAsync(rating);
        }

        public async Task DeleteRatingAsync(int id)
        {
            await _ratingRepository.DeleteAsync(id);
        }
    }
}


