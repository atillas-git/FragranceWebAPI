using AutoMapper;
using Application.Dtos.Rating;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Messages;
using Application.Exceptions;

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

        public async Task<RatingDto> GetRatingByIdAsync(int id)
        {
            var rating = await _ratingRepository.GetRatingByIdAsync(id);
            if (rating == null) { 
                throw new KeyNotFoundException(ResponseMessages.Rating_RatingDoesNotExist);
            }
            return _mapper.Map<RatingDto>(rating);  // Use AutoMapper to map entity to DTO
        }

        public async Task<IEnumerable<RatingDto>> GetRatingsByFragranceIdAsync(int fragranceId)
        {
            var ratings = await _ratingRepository.GetAllRatingsByFragranceIdAsync(fragranceId);
            return _mapper.Map<IEnumerable<RatingDto>>(ratings);
        }

        public async Task<IEnumerable<RatingDto>> GetRatingsByUserIdAsync(int userId)
        {
            var ratings = await _ratingRepository.GetAllRatingsByUserIdAsync(userId);
            return _mapper.Map<IEnumerable<RatingDto>>(ratings);
        }

        public async Task AddRatingAsync(RatingCreateUpdateDto ratingDto)
        {
            if (ratingDto == null || ratingDto.MasculinityRating == null || ratingDto.OverallRating == null
                || ratingDto.FemininityRating == null || ratingDto.PriceRating == null || ratingDto.UserId == null
                || ratingDto.FragranceId == null) { 
                throw new AppException(ResponseMessages.Shared_PleaseFillTheRequiredFields);
            }
            var rating = _mapper.Map<Rating>(ratingDto);  // Map DTO to entity
            await _ratingRepository.AddRatingAsync(rating);
        }

        public async Task UpdateRatingAsync(int id, RatingCreateUpdateDto ratingDto)
        {
            var rating = await _ratingRepository.GetRatingByIdAsync(id);
            if (rating == null)
            {
                throw new KeyNotFoundException(ResponseMessages.Rating_RatingDoesNotExist);
            }

            _mapper.Map(ratingDto, rating);  // Map updated DTO to existing entity
            await _ratingRepository.UpdateRatingAsync(rating);
        }

        public async Task DeleteRatingAsync(int id)
        {
            var rating = await _ratingRepository.GetRatingByIdAsync(id);
            if (rating == null)
            {
                throw new KeyNotFoundException(ResponseMessages.Rating_RatingDoesNotExist);
            }
            await _ratingRepository.DeleteRatingAsync(rating);
        }
    }
}


