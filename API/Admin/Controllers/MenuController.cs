using Admin.ApiRequest;
using Admin.ApiResponse;
using AdminServices.Interfaces;
using DomainModels.Models;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MenuController(IMenuService menuService) : ControllerBase
    {
        private readonly IMenuService _menuService = menuService;

        [HttpGet]
        public ActionResult<IEnumerable<MenuApiReponse>> GetMenus()
        {
            return Ok(_menuService.GetMenus());
        }

        [HttpPost("add")]
        public async Task<ActionResult> AddMenu(MenuApiRequest request)
        {
            var menu = new Menu
            {
                Name = request.Name,
                CreatedDateTime = DateTime.UtcNow,
                ModifiedDateTime = DateTime.UtcNow,
                Icon = request.Icon,
                Id = request.Id,
                IsActive = request.IsActive,
                Order = request.Order,
                Url = request.Url
            };
            var isAdded = await _menuService.AddMenu(menu);
            if (isAdded)
            {
                return Created("Menu added successfully",menu);
            }
            return BadRequest("Failed to add menu");
        }

    }
}