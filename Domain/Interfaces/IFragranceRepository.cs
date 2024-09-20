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
        Task DeleteFragranceAsync(int id);
        Task UpdateFragranceAsync(int id,Fragrance fragrance);
        Task<IEnumerable<Fragrance>> SearchAsync(string query);
    }
}
