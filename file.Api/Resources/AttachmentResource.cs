namespace file.Api.Resources
{
    public class AttachmentResource
    {
        public int id { get; set; }
        public string fileName {get; set;}
        public byte[] file { get; set; }
        public UserResource user { get; set; }
    }
}