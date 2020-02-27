using System.Collections;
using file.Core.Models;

namespace file.Core.Services
{
    public class IUserService
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetUserById(int id);
        Task<User> CreateUser(User user);
        Task UpdateUser(User userToUpdate, User user);
        Task DeleteUser(User user);
    }
}