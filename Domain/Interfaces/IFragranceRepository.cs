using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IFragranceRepository
    {
        Task<Fragrance> GetFragranceByIdAsync(int id);
        Task<IEnumerable<Fragrance>> GetAllFragrancesAsync();
        Task AddFragranceAsync(Fragrance fragrance);
        Task DeleteFragranceAsync(Fragrance fragrance);
        Task UpdateFragranceAsync(Fragrance fragrance);
        Task<IEnumerable<Fragrance>> SearchFragranceAsync(string query,int pageNumber,int pageSize);
        Task<IEnumerable<Fragrance>> GetFragrancesByBrandId(int id);
    }
}
