using DomainModels.Entities;

namespace AdminRepositories.Interfaces
{
    public interface IMenuRepository
    {
        IEnumerable<Menu> GetMenus();
        Task<Menu> GetMenu(int id);
        Task<bool> AddMenu(Menu menu);
    }
}