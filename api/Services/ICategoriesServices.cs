using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs;

namespace api.Services
{
    public interface ICategoriesServices
    {
        Task<List<ResponseCategoriesDTO>> GetAllAsync();
        Task<ResponseCategoriesDTO?> GetByIdAsync(int id);
        Task<ResponseCategoriesDTO> CreateAsync(CreateCategoriesDTO dto);
        Task<ResponseCategoriesDTO?> UpdateAsync(int id, UpdateCategoriesDTO dto);
    }
}