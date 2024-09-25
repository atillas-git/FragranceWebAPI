using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IFragranceNoteRepository
    {
        Task<FragranceNote> GetFragranceNoteByIdAsync(int id);
        Task<IEnumerable<FragranceNote>> GetAllFragranceNotesAsync();
        Task AddFragranceNoteAsync(FragranceNote fragranceNote);
        Task UpdateFragranceNoteAsync(FragranceNote fragranceNote);
        Task DeleteFragranceNoteAsync(FragranceNote fragranceNote);
        Task<IEnumerable<FragranceNote>> SearchFragranceNotesAsync(string query, int pageNumber,int pageSize);
    }
}

