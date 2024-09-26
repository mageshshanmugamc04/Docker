using DomainModels.Entities;

namespace AdminRepositories.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();
        bool AddUser(User user);
    }
}