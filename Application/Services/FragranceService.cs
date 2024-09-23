using AutoMapper;
using Application.Dtos.Fragrance;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Exceptions;
using Application.Messages;

namespace Application.Services
{
    public class FragranceService : IFragranceService
    {
        private readonly IFragranceRepository _fragranceRepository;
        private readonly IMapper _mapper;

        public FragranceService(IFragranceRepository fragranceRepository, IMapper mapper)
        {
            _fragranceRepository = fragranceRepository;
            _mapper = mapper;
        }

        public async Task<FragranceDto> GetFragranceAsync(int id)
        {
            var fragrance = await _fragranceRepository.GetFragranceByIdAsync(id);

            if (fragrance == null) {
                throw new AppException(ResponseMessages.Fragrance_FragranceDoesNotExists);
            }

            return _mapper.Map<FragranceDto>(fragrance);
        }

        public async Task<IEnumerable<FragranceDto>> GetAllFragrancesAsync()
        {
            var fragrances = await _fragranceRepository.GetAllFragrancesAsync();

            return _mapper.Map<IEnumerable<FragranceDto>>(fragrances);
        }

        public async Task AddFragranceAsync(FragranceCreateUpdateDto fragranceDto)
        {
            if(string.IsNullOrEmpty(fragranceDto.Name) || string.IsNullOrEmpty(fragranceDto.Gender)
                || String.IsNullOrEmpty(fragranceDto.Gender))
            {
                throw new AppException(ResponseMessages.Shared_PleaseFillTheRequiredFields);
            }
            var fragrance = _mapper.Map<Fragrance>(fragranceDto);
            await _fragranceRepository.AddFragranceAsync(fragrance);
        }

        public async Task UpdateFragranceAsync(int id, FragranceCreateUpdateDto fragranceDto)
        {
            var fragrance = await _fragranceRepository.GetFragranceByIdAsync(id);
            if (fragrance == null)
            {
                throw new AppException(ResponseMessages.Fragrance_FragranceDoesNotExists);
            };
            _mapper.Map(fragranceDto, fragrance);
            await _fragranceRepository.UpdateFragranceAsync(fragrance);
        }

        public async Task DeleteFragranceAsync(int id)
        {
            var fragrance = await _fragranceRepository.GetFragranceByIdAsync(id);
            if(fragrance == null)
            {
                throw new AppException(ResponseMessages.Fragrance_FragranceDoesNotExists);
            };
            await _fragranceRepository.DeleteFragranceAsync(fragrance);
        }

        public async Task<IEnumerable<FragranceDto>> SearchFragranceAsync(string query,int pageNumber,int pageSize)
        {
            var fragrances = await _fragranceRepository.SearchFragranceAsync(query,pageNumber,pageSize);
            var fragranceDtos = _mapper.Map<IEnumerable<FragranceDto>>(fragrances);
            return fragranceDtos;
        }
    }
}
