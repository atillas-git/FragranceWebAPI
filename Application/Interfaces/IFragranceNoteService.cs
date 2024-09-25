using Application.Dtos.FragranceNote;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IFragranceNoteService
    {
        Task<FragranceNoteDto> GetFragranceNoteByIdAsync(int id);  // Retrieve a single fragrance note by ID
        Task<IEnumerable<FragranceNoteDto>> GetAllFragranceNotesAsync();  // Retrieve all fragrance notes
        Task AddFragranceNoteAsync(FragranceNoteCreateUpdateDto fragranceNoteDto);  // Add a new fragrance note
        Task UpdateFragranceNoteAsync(int id, FragranceNoteCreateUpdateDto fragranceNoteDto);  // Update an existing fragrance note
        Task DeleteFragranceNoteAsync(int id);  // Delete a fragrance note
        Task<IEnumerable<FragranceNoteDto>> SearchFragranceNotesAsync(string query, int pageNumber, int pageSize);
    }
}


