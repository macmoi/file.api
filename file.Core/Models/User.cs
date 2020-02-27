using System.Collections.ObjectModel;
using System.Collections.Generic;
namespace file.Core.Models
{
    public class User
    {
        public User()
        {
            Files = new Collection<File>();
        }

        public int id { get; set; }
        public string name { get; set; }
        public string lastname { get; set; }
        public ICollection<Attachment> Files { get; set; }
    }
}