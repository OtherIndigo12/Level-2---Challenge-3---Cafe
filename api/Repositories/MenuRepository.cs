using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Controllers;
using api.Data;
using Microsoft.EntityFrameworkCore;
using Menu = api.models.Menu;

namespace api.Repositories
{
    public class MenuRepository : IMenuRepository
    {
        private readonly AppDbContext _db;
        public MenuRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<List<Menu>> GetAllAsync()
        {
            return await  _db.Menus.ToListAsync();
        }

        public async Task<Menu?> GetByIdAsync(int id)
        {
            return await _db.Menus.FindAsync(id);
        }

        public async Task<Menu> AddAsync(Menu menu)
        {
            _db.Menus.Add(menu);

            await _db.SaveChangesAsync();
            return menu;
        }

        public async Task UpdateAsync(Menu menu)
        {
            _db.Menus.Update(menu);
            await _db.SaveChangesAsync();
        }
    }
}