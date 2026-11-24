using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs;
using api.models;
using api.Repositories;

namespace api.Services
{
    public class ItemsServices : IItemsServices 
    {
        private readonly IItemsRepository _repository;
        public ItemsServices(IItemsRepository repository)
        {
            _repository = repository;
        }

        //Get All
        public async Task<List<ResponseItemsDTO>> GetAllAsync()
        {
            List<Items> items = await _repository.GetAllAsync();
            return items.Select(ToDto).ToList();
        }

        public async Task<ResponseItemsDTO?> GetByIdAsync(int id)
        {
            Items? items = await _repository.GetByIdAsync(id);
            if(items is null)
            {
                return null;
            }
            return ToDto(items);
        }

        //Add
        public async Task<ResponseItemsDTO> CreateAsync(CreateItemsDTO dto)
        {
            Items items = new Items();
            items.Name = dto.Name;
            items.Category_id = dto.Category_id;
            items.Price = dto.Price;
            items.Description = dto.Description;
            items.Tag = dto.Tag;
            

            _repository.AddAsync(items);

            Items saved = await _repository.AddAsync(items);

            return ToDto(items);
        }

        public async Task<ResponseItemsDTO?> UpdateAsync(int id, UpdateItemsDTO dto)
        {
            Items items = await _repository.GetByIdAsync(id);

            if (items is null)
            {
                return null;
            }

            items.Name = dto.Name;
            items.Category_id = dto.Category_id;
            items.Price = dto.Price;
            items.Description = dto.Description;
            items.Tag = dto.Tag;
              
            items.UpdatedAt = DateTime.UtcNow;

            await _repository.UpdateAsync(items);

            return ToDto(items);
        }

        //Helper
        private static ResponseItemsDTO ToDto(Items items)
        {
            return new ResponseItemsDTO
            {
                Id = items.Id,
                Name = items.Name,
                Category_id = items.Category_id,
                Price = items.Price,
                Description = items.Description,
                Tag = items.Tag
            };
        }
    }
}