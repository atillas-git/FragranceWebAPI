using AutoMapper;
using Application.Dtos.FragranceNote;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Messages;
using Application.Exceptions;

namespace Application.Services
{
    public class FragranceNoteService : IFragranceNoteService
    {
        private readonly IFragranceNoteRepository _fragranceNoteRepository;
        private readonly IMapper _mapper;

        public FragranceNoteService(IFragranceNoteRepository fragranceNoteRepository, IMapper mapper)
        {
            _fragranceNoteRepository = fragranceNoteRepository;
            _mapper = mapper;
        }

        public async Task<FragranceNoteDto> GetFragranceNoteByIdAsync(int id)
        {
            var fragranceNote = await _fragranceNoteRepository.GetFragranceNoteByIdAsync(id);
            if (fragranceNote == null) {
                throw new KeyNotFoundException(ResponseMessages.FragranceNote_FragranceNoteDoesNotExist);
            }
            return _mapper.Map<FragranceNoteDto>(fragranceNote);  // Use AutoMapper to map entity to DTO
        }

        public async Task<IEnumerable<FragranceNoteDto>> GetAllFragranceNotesAsync()
        {
            var fragranceNotes = await _fragranceNoteRepository.GetAllFragranceNotesAsync();
            return _mapper.Map<IEnumerable<FragranceNoteDto>>(fragranceNotes);  // Use AutoMapper to map entities to DTOs
        }

        public async Task AddFragranceNoteAsync(FragranceNoteCreateUpdateDto fragranceNoteDto)
        {
            if (string.IsNullOrEmpty(fragranceNoteDto.Name))
            {
                throw new AppException(ResponseMessages.Shared_PleaseFillTheRequiredFields);
            }
            var fragranceNote = _mapper.Map<FragranceNote>(fragranceNoteDto);  // Map DTO to entity
            await _fragranceNoteRepository.AddFragranceNoteAsync(fragranceNote);
        }

        public async Task UpdateFragranceNoteAsync(int id, FragranceNoteCreateUpdateDto fragranceNoteDto)
        {
            var fragranceNote = await _fragranceNoteRepository.GetFragranceNoteByIdAsync(id);
            if (fragranceNote == null)
            {
                throw new KeyNotFoundException(ResponseMessages.FragranceNote_FragranceNoteDoesNotExist);    
            }
            _mapper.Map(fragranceNoteDto, fragranceNote);  // Map updated DTO to existing entity
            await _fragranceNoteRepository.UpdateFragranceNoteAsync(fragranceNote);
        }

        public async Task DeleteFragranceNoteAsync(int id)
        {
            var fragranceNote = await _fragranceNoteRepository.GetFragranceNoteByIdAsync(id);
            if (fragranceNote == null)
            {
                throw new KeyNotFoundException(ResponseMessages.FragranceNote_FragranceNoteDoesNotExist);
            }
            await _fragranceNoteRepository.DeleteFragranceNoteAsync(fragranceNote);
        }

        public async Task<IEnumerable<FragranceNoteDto>> SearchFragranceNotesAsync(string query, int pageNumber, int pageSize)
        {
            var fragranceNotes = await _fragranceNoteRepository.SearchFragranceNotesAsync(query,pageNumber,pageSize);
            return _mapper.Map<IEnumerable<FragranceNoteDto>>(fragranceNotes);
        }
    }
}


