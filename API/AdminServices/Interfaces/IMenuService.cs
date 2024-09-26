using DomainModels.Models;

namespace AdminServices.Interfaces
{
    public interface IMenuService
    {
        IEnumerable<Menu> GetMenus();
        Task<bool> AddMenu(Menu menu);
    }
}