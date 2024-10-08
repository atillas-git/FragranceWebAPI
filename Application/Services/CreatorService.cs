﻿using AutoMapper;
using Application.Dtos.Creator;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Messages;
using Application.Exceptions;

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

        public async Task<CreatorDto> GetCreatorByIdAsync(int id)
        {
            var creator = await _creatorRepository.GetCreatorByIdAsync(id);
            if (creator == null) {
                throw new KeyNotFoundException(ResponseMessages.Creator_CreatorDoesNotExist);
            }
            return _mapper.Map<CreatorDto>(creator);  // Use AutoMapper to map entity to DTO
        }

        public async Task<IEnumerable<CreatorDto>> GetAllCreatorsAsync()
        {
            var creators = await _creatorRepository.GetAllCreatorsAsync();
            return _mapper.Map<IEnumerable<CreatorDto>>(creators);  // Use AutoMapper to map entities to DTOs
        }

        public async Task AddCreatorAsync(CreatorCreateUpdateDto creatorDto)
        {
            if (string.IsNullOrEmpty(creatorDto.Name))
            {
                throw new AppException(ResponseMessages.Shared_PleaseFillTheRequiredFields);
            }
            var creator = _mapper.Map<Creator>(creatorDto);
            await _creatorRepository.AddCreatorAsync(creator);
        }

        public async Task UpdateCreatorAsync(int id, CreatorCreateUpdateDto creatorDto)
        {
            var creator = await _creatorRepository.GetCreatorByIdAsync(id);
            if (creator == null)
            {
                throw new KeyNotFoundException(ResponseMessages.Creator_CreatorDoesNotExist);
            }
            _mapper.Map(creatorDto, creator);  // Map updated DTO to existing entity
            await _creatorRepository.UpdateCreatorAsync(creator);
        }

        public async Task DeleteCreatorAsync(int id)
        {
            var creator = await _creatorRepository.GetCreatorByIdAsync(id);
            if (creator == null)
            {
                throw new KeyNotFoundException(ResponseMessages.Creator_CreatorDoesNotExist);
            }
            await _creatorRepository.DeleteCreatorAsync(creator);
        }

        public async Task<IEnumerable<CreatorDto>> SearchCreatorsAsync(string query, int pageNumber, int pageSize)
        {
            var creators = await  _creatorRepository.SearchCreatorsAsync(query, pageNumber, pageSize);
            return _mapper.Map<IEnumerable<CreatorDto>>(creators);
        }
    }
}

