using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using Microsoft.EntityFrameworkCore;
using Items = api.models.Items;

namespace api.Repositories
{
    public class ItemsRepository : IItemsRepository
    {
        private readonly AppDbContext _db;
        public ItemsRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<List<Items>> GetAllAsync()
        {
            return await  _db.Items.ToListAsync();
        }

        public async Task<Items?> GetByIdAsync(int id)
        {
            return await _db.Items.FindAsync(id);
        }

        public async Task<Items> AddAsync(Items items)
        {
            _db.Items.Add(items);

            await _db.SaveChangesAsync();
            return items;
        }

        public async Task UpdateAsync(Items items)
        {
            _db.Items.Update(items);
            await _db.SaveChangesAsync();
        }


    }
}