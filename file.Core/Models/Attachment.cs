namespace file.Core.Models
{
    public class Attachment
    {
        public int id { get; set; }
        public string fileName { get; set; }
        public byte[] file { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}