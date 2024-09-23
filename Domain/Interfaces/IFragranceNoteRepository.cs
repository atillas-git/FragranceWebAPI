using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IFragranceNoteRepository
    {
        Task<FragranceNote> GetByIdAsync(int id);
        Task<IEnumerable<FragranceNote>> GetAllAsync();
        Task AddAsync(FragranceNote fragranceNote);
        Task UpdateAsync(FragranceNote fragranceNote);
        Task DeleteAsync(FragranceNote fragranceNote);
        Task<IEnumerable<FragranceNote>> SearchAsync(string query, int pageNumber,int pageSize);
    }
}

