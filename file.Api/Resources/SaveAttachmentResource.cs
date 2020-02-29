using System.ComponentModel.DataAnnotations;

namespace file.Api.Resources
{
    public class SaveAttachmentResource
    {
        [Required]
        public int id { get; set; }
        [Required]
        [MaxLength(40)]
        public string fileName {get; set;}
        [Required]
        public byte[] file { get; set; }
    }
}