using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ICreatorRepository
    {
        Task<Creator> GetByIdAsync(int id);
        Task<IEnumerable<Creator>> GetAllAsync();
        Task AddAsync(Creator creator);
        Task UpdateAsync(Creator creator);
        Task DeleteAsync(int id);
    }
}
