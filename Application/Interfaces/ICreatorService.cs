using Application.Dtos.Creator;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ICreatorService
    {
        Task<CreatorDto> GetCreatorAsync(int id);  // Retrieve a single creator by ID
        Task<IEnumerable<CreatorDto>> GetAllCreatorsAsync();  // Retrieve all creators
        Task AddCreatorAsync(CreatorCreateUpdateDto creatorDto);  // Add a new creator
        Task UpdateCreatorAsync(int id, CreatorCreateUpdateDto creatorDto);  // Update an existing creator
        Task DeleteCreatorAsync(int id);  // Delete a creator
    }
}

