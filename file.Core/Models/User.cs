using System.Collections.ObjectModel;
using System.Collections.Generic;
namespace file.Core.Models
{
    public class User
    {
        public User()
        {
            attachments = new Collection<Attachment>();
        }

        public int id { get; set; }
        public string name { get; set; }
        public string lastname { get; set; }
        public IList<Attachment> attachments { get; set; }
    }
}