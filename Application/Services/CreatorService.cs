using AutoMapper;
using Application.Dtos.Creator;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class CreatorService : ICreatorService
    {
        private readonly ICreatorRepository _creatorRepository;
        private readonly IMapper _mapper;

        public CreatorService(ICreatorRepository creatorRepository, IMapper mapper)
        {
            _creatorRepository = creatorRepository;
            _mapper = mapper;
        }

        public async Task<CreatorDto> GetCreatorAsync(int id)
        {
            var creator = await _creatorRepository.GetByIdAsync(id);
            return _mapper.Map<CreatorDto>(creator);  // Use AutoMapper to map entity to DTO
        }

        public async Task<IEnumerable<CreatorDto>> GetAllCreatorsAsync()
        {
            var creators = await _creatorRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CreatorDto>>(creators);  // Use AutoMapper to map entities to DTOs
        }

        public async Task AddCreatorAsync(CreatorCreateUpdateDto creatorDto)
        {
            var creator = _mapper.Map<Creator>(creatorDto);  // Map DTO to entity
            await _creatorRepository.AddAsync(creator);
        }

        public async Task UpdateCreatorAsync(int id, CreatorCreateUpdateDto creatorDto)
        {
            var creator = await _creatorRepository.GetByIdAsync(id);
            if (creator == null) return;

            _mapper.Map(creatorDto, creator);  // Map updated DTO to existing entity
            await _creatorRepository.UpdateAsync(creator);
        }

        public async Task DeleteCreatorAsync(int id)
        {
            await _creatorRepository.DeleteAsync(id);
        }
    }
}

