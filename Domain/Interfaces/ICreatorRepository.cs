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
        Task<Creator> GetCreatorByIdAsync(int id);
        Task<IEnumerable<Creator>> GetAllCreatorsAsync();
        Task AddCreatorAsync(Creator creator);
        Task UpdateCreatorAsync(Creator creator);
        Task DeleteCreatorAsync(Creator creator);
        Task<IEnumerable<Creator>> SearchCreatorsAsync(string query,int pageNumber,int pageSize);
    }
}
