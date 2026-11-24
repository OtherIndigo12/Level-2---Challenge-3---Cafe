using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs;
using api.models;
using api.Repositories;

namespace api.Services
{
    public class MenuServices : IMenuServices
    {
       private readonly IMenuRepository _repository;

        public MenuServices(IMenuRepository repository)
        {
            _repository = repository;
        } 

        //Get All
        public async Task<List<ResponseMenuDTO>> GetAllAsync()
        {
            List<Menu> menus = await _repository.GetAllAsync();
            return menus.Select(ToDto).ToList();
        }

        //ID
        public async Task<ResponseMenuDTO?> GetByIdAsync(int id)
        {
            Menu? menus = await _repository.GetByIdAsync(id);
            if(menus is null)
            {
                return null;
            }
            return ToDto(menus);
        }


        //Add
        public async Task<ResponseMenuDTO> CreateAsync(CreateMenuDTO dto)
        {
            Menu menus = new Menu();
            menus.Name = dto.Name;
            menus.Tagline = dto.Tagline;
            menus.Address = dto.Address;
            menus.Hours = dto.Hours;
            menus.Phone = dto.Phone;

            _repository.AddAsync(menus);

            Menu saved = await _repository.AddAsync(menus);

            return ToDto(menus);
        }

         public async Task<ResponseMenuDTO?> UpdateAsync(int id, UpdateMenuDTO dto)
        {
            Menu menus = await _repository.GetByIdAsync(id);

            if (menus is null)
            {
                return null;
            }

            menus.Name = dto.Name;
            menus.Tagline = dto.Tagline;
            menus.Address = dto.Address;
            menus.Hours = dto.Hours;
            menus.Phone = dto.Phone;
              
            menus.UpdatedAt = DateTime.UtcNow;

            await _repository.UpdateAsync(menus);

            return ToDto(menus);
        }

        //Helper
        private static ResponseMenuDTO ToDto(Menu menu)
        {
            return new ResponseMenuDTO
            {
                Id = menu.Id,
                Name = menu.Name,
                Tagline = menu.Tagline,
                Address = menu.Address,
                Hours = menu.Hours,
                Phone = menu.Phone
                
            };
        }
    }
}