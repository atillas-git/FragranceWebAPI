using AutoMapper;
using Application.Dtos.FragranceNote;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public async Task<FragranceNoteDto> GetFragranceNoteAsync(int id)
        {
            var fragranceNote = await _fragranceNoteRepository.GetByIdAsync(id);
            return _mapper.Map<FragranceNoteDto>(fragranceNote);  // Use AutoMapper to map entity to DTO
        }

        public async Task<IEnumerable<FragranceNoteDto>> GetAllFragranceNotesAsync()
        {
            var fragranceNotes = await _fragranceNoteRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<FragranceNoteDto>>(fragranceNotes);  // Use AutoMapper to map entities to DTOs
        }

        public async Task AddFragranceNoteAsync(FragranceNoteCreateUpdateDto fragranceNoteDto)
        {
            var fragranceNote = _mapper.Map<FragranceNote>(fragranceNoteDto);  // Map DTO to entity
            await _fragranceNoteRepository.AddAsync(fragranceNote);
        }

        public async Task UpdateFragranceNoteAsync(int id, FragranceNoteCreateUpdateDto fragranceNoteDto)
        {
            var fragranceNote = await _fragranceNoteRepository.GetByIdAsync(id);
            if (fragranceNote == null) return;

            _mapper.Map(fragranceNoteDto, fragranceNote);  // Map updated DTO to existing entity
            await _fragranceNoteRepository.UpdateAsync(fragranceNote);
        }

        public async Task DeleteFragranceNoteAsync(int id)
        {
            await _fragranceNoteRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<FragranceNoteDto>> SearchAsync(string query, int pageNumber, int pageSize)
        {
            var fragranceNotes = await _fragranceNoteRepository.SearchAsync(query,pageNumber,pageSize);
            return _mapper.Map<IEnumerable<FragranceNoteDto>>(fragranceNotes);
        }
    }
}


