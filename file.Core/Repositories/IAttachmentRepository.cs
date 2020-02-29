using System.Collections.Generic;
using System.Threading.Tasks;
using file.Core.Models;

namespace file.Core.Repositories
{
    public interface IAttachmentRepository : IRepository<Attachment>
    {
        Task<IEnumerable<Attachment>> GetAllAttachment();
        Task<IEnumerable<Attachment>> GetAttachmentsByUserId(int userId);
    }
}