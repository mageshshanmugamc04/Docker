using AdminRepositories.Context;
using AdminRepositories.Interfaces;
using DomainModels.Entities;
using Microsoft.EntityFrameworkCore;

namespace AdminRepositories.Implementations
{
    public class MenuRepository(AdminDbContext dbContext) : IMenuRepository
    {
        private readonly AdminDbContext _dbContext = dbContext;

        public async Task<Menu> GetMenu(int id) => await _dbContext.Menu.Where(menu => menu.Id == id).FirstOrDefaultAsync();

        public IEnumerable<Menu> GetMenus()
        {
            return [.. _dbContext.Set<Menu>().OrderBy(m => m.Order)];
        }

        public async Task<bool> AddMenu(Menu menu)
        {
            var isAdded = false;
            try
            {
                _dbContext.Menu.Add(menu);
                await _dbContext.SaveChangesAsync();
                isAdded = true;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                isAdded = false;
            }
            return isAdded;
        }

    }
}