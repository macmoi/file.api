using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using file.Api.Extensions;
using file.Api.Resources;
using file.Core.Models;
using file.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace file.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttachmentController : ControllerBase
    {
        private readonly IAttachmentService _attachmentService;
        private readonly IMapper _mapper;

        public AttachmentController(IAttachmentService attachmentService, IMapper mapper)
        {
            _attachmentService = attachmentService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AttachmentResource>> GetAttachment(int id)
        {
            if(id == 0)
                return BadRequest();

            var attachment = await _attachmentService.GetAttachmentById(id);
            var attachmentResult = _mapper.Map<Attachment, AttachmentResource>(attachment);
            return Ok(attachmentResult);
        }

        [Route("user/{userId}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AttachmentResource>>> GetAttachmentsByUser(int userId)
        {
            if(userId == 0)
                return BadRequest();

            var attachment = await _attachmentService.GetAttachmentsByUserId(userId);
            var attachmentResult = _mapper.Map<IEnumerable<Attachment>, IEnumerable<AttachmentResource>>(attachment);
            return Ok(attachmentResult);
        }

        [HttpPost]
        public async Task<ActionResult<AttachmentResource>> UploadAttachment([FromForm]SaveAttachmentResource attachmentResource)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            if(attachmentResource.file.Length > 256000)
                return BadRequest("Maximum payload size 500KB");

            var attachment = _mapper.Map<SaveAttachmentResource, Attachment>(attachmentResource);
            var uploadedAttachment = await _attachmentService.UploadAttachment(attachment);
            var attachmentResult = _mapper.Map<Attachment, AttachmentResource>(uploadedAttachment);
            return Ok(attachmentResult); 
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAttachment(int id)
        {
            if(id == 0)
                return BadRequest();
            
            var attachment = await _attachmentService.GetAttachmentById(id);

            if(attachment == null)
                return NotFound("Attachment Not found");
            
            await _attachmentService.DeleteAttachment(attachment);
            return Ok("Deleted");
        }
    }
}