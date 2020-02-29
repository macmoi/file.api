using AutoMapper;
using file.Api.Resources;
using file.Core.Models;

namespace file.Api.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to Resources
            CreateMap<User, UserResource>();
            CreateMap<Attachment, AttachmentResource>();

            // Resources to Domain
            CreateMap<UserResource, User>();
            CreateMap<AttachmentResource, Attachment>();
        }
    }
}