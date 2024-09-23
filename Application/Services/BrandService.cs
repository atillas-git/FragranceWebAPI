using Application.Dtos.Brand;
using Application.Exceptions;
using Application.Interfaces;
using Application.Messages;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;

        public BrandService(IBrandRepository brandRepository,IMapper mapper)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
        }

        public async Task AddBrandAsync(BrandCreateUpdateDto brandCreateUpdateDto)
        {
            if (string.IsNullOrEmpty(brandCreateUpdateDto.Name) || string.IsNullOrEmpty(brandCreateUpdateDto.Country)){
                throw new AppException(ResponseMessages.Brand_NameCountryRequired);
            }
            var brand = await _brandRepository.GetBrandByNameAsync(brandCreateUpdateDto.Name);
            
            if(brand != null)
            {
                throw new AppException(ResponseMessages.Brand_BrandAlreadyExists);
            }
            var brand2Add = _mapper.Map<Brand>(brandCreateUpdateDto);

            await _brandRepository.AddBrandAsync(brand2Add);
        }

        public async Task DeleteBrandAsync(int id)
        {
            var brand = await _brandRepository.GetBrandByIdAsync(id);
            if(brand == null)
            {
                throw new AppException(ResponseMessages.Brand_BrandDoesNotExists);
            }
            await _brandRepository.DeleteBrandAsync(brand);
        }

        public async Task<IEnumerable<BrandDto>> GetAllBrandsAsync()
        {
            var brands = await _brandRepository.GetAllBrandsAsync();
            return _mapper.Map<IEnumerable<BrandDto>>(brands);
        }

        public async Task<BrandDto> GetBrandByIdAsync(int id)
        {
            var brand = await _brandRepository.GetBrandByIdAsync(id);
            if(brand == null)
            {
                throw new AppException(ResponseMessages.Brand_BrandDoesNotExists);
            }
            throw new NotImplementedException();
        }

        public async Task<BrandDto> GetBrandByNameAsync(string name)
        {
            var brand = await _brandRepository.GetBrandByNameAsync(name);
            if(brand == null)
            {
                throw new AppException(ResponseMessages.Brand_BrandDoesNotExists);
            }
            return _mapper.Map<BrandDto>(brand);
        }

        public async Task<IEnumerable<BrandDto>> SearchBrandAsync(string query, int pageNumber = 1, int pageSize = 10)
        {
            var brands = await _brandRepository.SearchBrandAsync(query,pageNumber,pageSize);
            return _mapper.Map<IEnumerable<BrandDto>>(brands);
        }

        public async Task UpdateBrandAsync(int id, BrandCreateUpdateDto brandCreateUpdateDto)
        {
            var brand = await _brandRepository.GetBrandByIdAsync(id);
            if (brand == null) {
                throw new AppException(ResponseMessages.Brand_BrandDoesNotExists);
            }
            _mapper.Map(brandCreateUpdateDto,brand);
            await _brandRepository.UpdateBrandAsync(brand);
        }
    }
}
