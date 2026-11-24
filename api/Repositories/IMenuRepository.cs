using api.models;

namespace api.Repositories
{
    public interface IMenuRepository
    {
        Task<List<Menu>> GetAllAsync();
        Task<Menu?> GetByIdAsync(int Id);
        Task<Menu> AddAsync(Menu menu);
        Task UpdateAsync(Menu menu);
    }
}