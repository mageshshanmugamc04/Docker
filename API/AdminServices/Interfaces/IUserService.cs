using DomainModels.Models;

namespace AdminServices.Interfaces
{
    public interface IUserService
    {
        IEnumerable<User> GetUsers();
        bool AddUser(User user);
    }
}