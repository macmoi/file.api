using System.ComponentModel.DataAnnotations;

namespace file.Api.Resources
{
    public class SaveUserResource
    {
        [Required]
        [MaxLength(40)]
        public string name { get; set; }
        [Required]
        [MaxLength(40)]
        public string lastName { get; set; }
    }
}