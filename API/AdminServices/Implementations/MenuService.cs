using AdminRepositories.Interfaces;
using AdminServices.Interfaces;
using DomainModels.Models;

namespace AdminServices.Implementations
{
    public class MenuService(IMenuRepository menuRepository) : IMenuService
    {

        private readonly IMenuRepository _menuRepository = menuRepository;
        public IEnumerable<Menu> GetMenus()
        {
            var menu = _menuRepository.GetMenus();
            return menu.Select(m => new Menu
            {
                Name = m.Name,
                CreatedDateTime = m.CreatedDateTime,
                ModifiedDateTime = m.ModifiedDateTime,
                Icon = m.Icon,
                Id = m.Id,
                IsActive = m.IsActive,
                Order = m.Order,
                Url = m.Url
            });
        }

        public async Task<bool> AddMenu(Menu menu)
        {
            var dmenu = new DomainModels.Entities.Menu
            {
                Name = menu.Name,
                CreatedDateTime = DateTime.UtcNow,
                ModifiedDateTime = DateTime.UtcNow,
                Icon = menu.Icon,
                Id = menu.Id,
                IsActive = menu.IsActive,
                Order = menu.Order,
                Url = menu.Url
            };
            return await _menuRepository.AddMenu(dmenu);
        }
    }
}