using System;
using System.Threading.Tasks;
using file.Core.Repositories;

namespace file.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        IAttachmentRepository Attachments { get; }       
        Task<int> Commit();  
    }
}
