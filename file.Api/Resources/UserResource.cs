using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace file.Api.Resources
{
    public class UserResource
    {
        [Required]
        public int id { get; set; }
        [Required]
        [MaxLength(40)]
        public string name { get; set; }
        [Required]
        [MaxLength(40)]
        public string lastName { get; set; }
        public IList<AttachmentResource> attachmentResources { get; set; }
    }
}