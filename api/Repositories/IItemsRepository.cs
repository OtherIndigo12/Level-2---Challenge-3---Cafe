using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.models;

namespace api.Repositories
{
    public interface IItemsRepository
    {
        Task<List<Items>> GetAllAsync();
        Task<Items?> GetByIdAsync(int Id);
        Task<Items> AddAsync(Items items);
        Task UpdateAsync(Items items);
    }
}