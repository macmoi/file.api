using System.IO;
using AutoMapper;
using Microsoft.AspNetCore.Http;

namespace file.Api.Utils
{
    public class FormFileByteArrayValueConverter : IValueConverter<IFormFile,byte[]>
    {
        public byte[] Convert(IFormFile sourceMember, ResolutionContext context)
        {
            byte[] file = null;
            using(MemoryStream memoryStream = new MemoryStream())
            {
                sourceMember.OpenReadStream().CopyTo(memoryStream);
                file = memoryStream.ToArray();
            }
            return file;
        }
    }
}