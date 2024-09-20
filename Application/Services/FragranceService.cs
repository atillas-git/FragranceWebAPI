using AutoMapper;
using Application.Dtos.Fragrance;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

            // Use AutoMapper to convert entity to DTO
            return _mapper.Map<FragranceDto>(fragrance);
        }

        public async Task<IEnumerable<FragranceDto>> GetAllFragrancesAsync()
        {
            var fragrances = await _fragranceRepository.GetAllFragrancesAsync();

            // Use AutoMapper to map list of Fragrances to list of FragranceDto
            return _mapper.Map<IEnumerable<FragranceDto>>(fragrances);
        }

        public async Task AddFragranceAsync(FragranceCreateUpdateDto fragranceDto)
        {
            // Map the DTO to the Fragrance entity
            var fragrance = _mapper.Map<Fragrance>(fragranceDto);

            // Add the fragrance to the repository
            await _fragranceRepository.AddFragranceAsync(fragrance);
        }

        public async Task UpdateFragranceAsync(int id, FragranceCreateUpdateDto fragranceDto)
        {
            // Retrieve the existing fragrance entity
            var fragrance = await _fragranceRepository.GetFragranceByIdAsync(id);
            if (fragrance == null) return;

            // Map the updated DTO values to the existing entity
            _mapper.Map(fragranceDto, fragrance);

            // Update the fragrance in the repository
            await _fragranceRepository.UpdateFragranceAsync(id, fragrance);
        }

        public async Task DeleteFragranceAsync(int id)
        {
            // Delete the fragrance from the repository
            await _fragranceRepository.DeleteFragranceAsync(id);
        }

        public async Task<IEnumerable<FragranceDto>> SearchAsync(string query)
        {
            var fragrances = await _fragranceRepository.SearchAsync(query);

            var fragranceDtos = _mapper.Map<IEnumerable<FragranceDto>>(fragrances);

            return fragranceDtos;
        }
    }
}
