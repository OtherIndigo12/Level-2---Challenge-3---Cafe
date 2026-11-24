using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.models;

namespace api.Repositories
{
    public interface ICategoriesRepository
    {
        Task<List<Categories>> GetAllAsync();
        Task<Categories?> GetByIdAsync(int Id);
        Task<Categories> AddAsync(Categories categories);
        Task UpdateAsync(Categories categories);
    }
}