using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs;

namespace api.Services
{
    public interface IItemsServices
    {
        Task<List<ResponseItemsDTO>> GetAllAsync();
        Task<ResponseItemsDTO?> GetByIdAsync(int id);
        Task<ResponseItemsDTO> CreateAsync(CreateItemsDTO dto);
        Task<ResponseItemsDTO?> UpdateAsync(int id, UpdateItemsDTO dto);
    }
}