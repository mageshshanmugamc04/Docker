using AdminRepositories.Context;
using DomainModels.Entities;
using AdminRepositories.Interfaces;

namespace AdminRepositories.Implementations
{
    public class UserRepository(AdminDbContext dbContext) : IUserRepository
    {
        private readonly AdminDbContext _dbContext = dbContext;

        /// <summary>
        /// Get all users from database
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public IEnumerable<User> GetUsers()
        {
            return [.. _dbContext.Set<User>()];
        }
        
        /// <summary>
        /// Add a new user to the database
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool AddUser(User user)
        {
            var isAdded = false;
            try
            {
                _dbContext.User.Add(user);
                _dbContext.SaveChanges();
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