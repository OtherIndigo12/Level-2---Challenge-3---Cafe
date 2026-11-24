using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs;

namespace api.Services
{
    public interface IMenuServices
    {
        Task<List<ResponseMenuDTO>> GetAllAsync();
        Task<ResponseMenuDTO?> GetByIdAsync(int id);
        Task<ResponseMenuDTO> CreateAsync(CreateMenuDTO dto);
        Task<ResponseMenuDTO?> UpdateAsync(int id, UpdateMenuDTO dto);
    }
}