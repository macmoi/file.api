using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace file.Api.Resources
{
    public class SaveAttachmentResource
    {
        [Required]
        [MaxLength(40)]
        public string fileName { get; set; }

        [Required]
        public IFormFile file { get; set; }
        
        [Required]
        public int userId { get; set; }
    }
}