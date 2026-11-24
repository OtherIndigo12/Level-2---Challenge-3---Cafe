using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs;
using api.models;
using api.Repositories;

namespace api.Services
{
    public class CategoriesServices : ICategoriesServices
    {
        private readonly ICategoriesRepository _repository;

        public CategoriesServices(ICategoriesRepository repository)
        {
            _repository = repository;
        } 

        //Get All
        public async Task<List<ResponseCategoriesDTO>> GetAllAsync()
        {
            List<Categories> categories = await _repository.GetAllAsync();
            return categories.Select(ToDto).ToList();
        }

        public async Task<ResponseCategoriesDTO?> GetByIdAsync(int id)
        {
            Categories? categories = await _repository.GetByIdAsync(id);
            if(categories is null)
            {
                return null;
            }
            return ToDto(categories);
        }

        //Add
        public async Task<ResponseCategoriesDTO> CreateAsync(CreateCategoriesDTO dto)
        {
            Categories categories = new Categories();
            categories.Name = dto.Name;

            _repository.AddAsync(categories);

            Categories saved = await _repository.AddAsync(categories);

            return ToDto(categories);
        }

        public async Task<ResponseCategoriesDTO?> UpdateAsync(int id, UpdateCategoriesDTO dto)
        {
            Categories categories = await _repository.GetByIdAsync(id);

            if (categories is null)
            {
                return null;
            }

            categories.Name = dto.Name;
              
            categories.UpdatedAt = DateTime.UtcNow;

            await _repository.UpdateAsync(categories);

            return ToDto(categories);
        }
        //Helper
        private static ResponseCategoriesDTO ToDto(Categories categories)
        {
            return new ResponseCategoriesDTO
            {
                Id = categories.Id,
                Name = categories.Name
            };
        }
    }
}