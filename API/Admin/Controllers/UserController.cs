using Admin.ApiRequest;
using AdminServices.Interfaces;
using DomainModels.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;

namespace Admin.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController(IUserService userService) : ControllerBase
    {
        private readonly IUserService _userService = userService;

        /// <summary>
        /// Get all users from database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            return Ok(_userService.GetUsers());
        }
        /// <summary>
        /// Add a new user to the database
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost("add")]
        public ActionResult AddUser(UserApiRequest user)
        {
            var usr = new User{
                Email = user.Email,
                Name = user.Name
            };

            var isAdded = _userService.AddUser(usr);
            if (isAdded)
            {
                return Created("User added successfully", usr);
            }
            return BadRequest("Failed to add user");
        }
    }
}