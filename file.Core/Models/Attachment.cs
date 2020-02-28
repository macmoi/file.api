namespace file.Core.Models
{
    public class Attachment
    {
        public int id { get; set; }
        public string fileName { get; set; }
        public byte[] file { get; set; }
        public int userId { get; set; }
        public User user { get; set; }
    }
}