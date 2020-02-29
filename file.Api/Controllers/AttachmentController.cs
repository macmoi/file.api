using AutoMapper;
using file.Core.Services;

namespace file.Api.Controllers
{
    public class AttachmentController
    {
        private readonly IAttachmentService _attachmentService;
        private readonly IMapper _mapper;

        public AttachmentController(IAttachmentService attachmentService, IMapper mapper)
        {
            _attachmentService = attachmentService;
            _mapper = mapper;
        }
    }
}