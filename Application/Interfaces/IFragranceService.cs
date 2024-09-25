using Application.Dtos.Fragrance;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IFragranceService
    {
        Task<FragranceDto> GetFragranceByIdAsync(int id);  // Retrieve a single fragrance by ID
        Task<IEnumerable<FragranceDto>> GetAllFragrancesAsync();  // Retrieve all fragrances
        Task AddFragranceAsync(FragranceCreateUpdateDto fragranceDto);  // Add a new fragrance
        Task UpdateFragranceAsync(int id, FragranceCreateUpdateDto fragranceDto);  // Update an existing fragrance
        Task DeleteFragranceAsync(int id);  // Delete a fragrance
        Task<IEnumerable<FragranceDto>> SearchFragranceAsync(string query,int pageNumber,int pageSize);
        Task<IEnumerable<FragranceDto>> GetFragrancesByBrandId(int id);
    }
}
