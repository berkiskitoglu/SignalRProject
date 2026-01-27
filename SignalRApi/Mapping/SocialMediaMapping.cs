using AutoMapper;
using SignalR.DtoLayer.SocialMediaDtos;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Mapping
{
    public class SocialMediaMapping : Profile
    {
        public SocialMediaMapping()
        {
            CreateMap<SocialMedia, ResultSocialMediaDto>();
            CreateMap<SocialMedia, GetSocialMediaDto>();

            CreateMap<CreateSocialMediaDto, SocialMedia>();
            CreateMap<UpdateSocialMediaDto, SocialMedia>();
        }
    }
}
