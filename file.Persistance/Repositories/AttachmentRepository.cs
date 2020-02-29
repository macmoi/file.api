
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using file.Core.Models;
using file.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace file.Persistance.Repositories
{
    public class AttachmentRepository : BaseRepository<Attachment>, IAttachmentRepository
    {
        public AttachmentRepository(ApiDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Attachment>> GetAllAttachment()
        {
            return await _context.Attachments.Include(a => a.user).ToListAsync();
        }

        public async Task<IEnumerable<Attachment>> GetAttachmentsByUserId(int userId)
        {
            return await _context.Attachments.Where(p => p.userId == userId).ToListAsync();
        }

        public async Task<Attachment> GetAttachmentWithUserById(int id)
        {
            return await _context.Attachments.Include(a => a.user).SingleOrDefaultAsync(a => a.id == id);
        }
    }
}