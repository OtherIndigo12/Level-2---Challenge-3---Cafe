using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.models;
using Microsoft.EntityFrameworkCore;
using Menu = api.models.Menu;

namespace api.Repositories
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly AppDbContext _db;
        public CategoriesRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<List<Categories>> GetAllAsync()
        {
            return await  _db.Categories.ToListAsync();
        }

        public async Task<Categories?> GetByIdAsync(int id)
        {
            return await _db.Categories.FindAsync(id);
        }

        public async Task<Categories> AddAsync(Categories categories)
        {
            _db.Categories.Add(categories);

            await _db.SaveChangesAsync();
            return categories;
        }

        public async Task UpdateAsync(Categories categories)
        {
            _db.Categories.Update(categories);
            await _db.SaveChangesAsync();
        }
    }
}