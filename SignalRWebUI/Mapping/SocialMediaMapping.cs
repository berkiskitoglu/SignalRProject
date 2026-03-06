using AutoMapper;
using SignalRWebUI.Dtos.SocialMediaDtos;
using SignalRWebUI.ViewModels;

namespace SignalRWebUI.Mapping
{
    public class SocialMediaMapping : Profile
    {
        public SocialMediaMapping()
        {
            CreateMap<ResultSocialMediaDto, SocialMediaViewModel>();
            CreateMap<GetSocialMediaDto, UpdateSocialMediaDto>();
        }
    }
}
