using AdminRepositories.Interfaces;
using AdminServices.Interfaces;
using DomainModels.Models;

namespace AdminServices.Implementations
{
    public class UserService(IUserRepository userRepository) : IUserService
    {
         private readonly IUserRepository _userRepository = userRepository;

        public IEnumerable<User> GetUsers()
        {
            List<User> users = [];
            users = _userRepository.GetUsers().Select(user => new User
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
            }).ToList();
            return users;
        }

        public bool AddUser(User user)
        {
            var isAdded = false;
            try
            {
                var userToAdd = new DomainModels.Entities.User
                {
                    Id = user.Id,
                    Name = user.Name,
                    Email = user.Email,
                    CreatedDateTime = DateTime.UtcNow,
                    ModifiedDateTime = DateTime.UtcNow,
                };
                isAdded = _userRepository.AddUser(userToAdd);
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