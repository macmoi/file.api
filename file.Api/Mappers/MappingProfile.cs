using System.IO;
using AutoMapper;
using file.Api.Resources;
using file.Api.Utils;
using file.Core.Models;
using Microsoft.AspNetCore.Http;

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
            CreateMap<SaveUserResource, User>();
            CreateMap<UserResource, User>();
            CreateMap<SaveAttachmentResource, Attachment>()
                .ForMember(
                    dest => dest.file,
                    opt => opt.ConvertUsing(new FormFileByteArrayValueConverter(), src => src.file)
                );

        }
    }
}