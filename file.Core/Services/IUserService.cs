using System.Collections.Generic;
using System.Threading.Tasks;
using file.Core.Models;

namespace file.Core.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetUserById(int id);
        Task<User> GetUserWithFilesById(int id);
        Task<User> CreateUser(User user);
        Task UpdateUser(User userToUpdate, User user);
        Task DeleteUser(User user);
    }
}