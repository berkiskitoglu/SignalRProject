using AutoMapper;
using SignalRWebUI.Dtos.SocialMediaDtos;
using SignalRWebUI.ViewModels.SocialMediaViewModels;

namespace SignalRWebUI.Mapping
{
    public class SocialMediaMapping : Profile
    {
        public SocialMediaMapping()
        {
            CreateMap<ResultSocialMediaDto, ResultSocialMediaViewModel>();
            CreateMap<GetSocialMediaDto, UpdateSocialMediaViewModel>();
            CreateMap<CreateSocialMediaViewModel, CreateSocialMediaDto>();
            CreateMap<UpdateSocialMediaViewModel, UpdateSocialMediaDto>();
        }
    }
}