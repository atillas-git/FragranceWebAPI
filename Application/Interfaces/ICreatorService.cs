using Application.Dtos.Creator;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ICreatorService
    {
        Task<CreatorDto> GetCreatorByIdAsync(int id);  // Retrieve a single creator by ID
        Task<IEnumerable<CreatorDto>> GetAllCreatorsAsync();  // Retrieve all creators
        Task AddCreatorAsync(CreatorCreateUpdateDto creatorDto);  // Add a new creator
        Task UpdateCreatorAsync(int id, CreatorCreateUpdateDto creatorDto);  // Update an existing creator
        Task DeleteCreatorAsync(int id);  // Delete a creator
        Task<IEnumerable<CreatorDto>> SearchCreatorsAsync(string query, int pageNumber, int pageSize);
    }
}

