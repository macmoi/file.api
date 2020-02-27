namespace file.Core.Models
{
    public class File
    {
        public int id { get; set; }
        public string fileName { get; set; }
        public byte[] file { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}