using System;
using System.Collections;
using System.Threading.Tasks;
using file.Core.Models;

namespace file.Core.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<IEnumerable<User>> GetAllUsersWithFiles();
        Task<User> GetUserWithFileById(int id);
        Task<IEnumerable<User>> GetAllUsersWithFileByFileId();
    }
}