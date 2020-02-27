using file.Core.Models;
namespace file.Core.Repositories
{
    public interface IAttachmentRepository : IRepository<Attachment>
    {
        Task<IEnumerable<Attachment>> GetAllAttachment();
        Task<Attachment> GetAttachmentWithMusicsById(int id);
    }
}