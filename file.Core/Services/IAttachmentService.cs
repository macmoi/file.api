using System.Collections.Generic;
using System.Threading.Tasks;
using file.Core.Models;

namespace file.Core.Services
{
    public interface IAttachmentService
    {
        Task<IEnumerable<Attachment>> GetAttachmentsWithUser();
        Task<Attachment> GetAttachmenByIdt(int id);
        Task<IEnumerable<Attachment>> GetAttachmentsByUserId(int userId);
        Task<Attachment> UploadAttachment(Attachment attachment);
        Task DeleteMusic(Attachment attachment);
    }
}