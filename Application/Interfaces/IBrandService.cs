using Application.Dtos.Brand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IBrandService
    {
        Task<BrandDto> GetBrandByIdAsync(int id);
        Task<BrandDto> GetBrandByNameAsync(string name);
        Task<IEnumerable<BrandDto>> GetAllBrandsAsync();
        Task AddBrandAsync(BrandCreateUpdateDto brandCreateUpdateDto);
        Task UpdateBrandAsync(int id,BrandCreateUpdateDto brandCreateUpdateDto);
        Task DeleteBrandAsync(int id);
        Task<IEnumerable<BrandDto>> SearchBrandAsync(string query, int pageSize, int pageNumber);
    }
}
