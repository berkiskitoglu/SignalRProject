using AutoMapper;
using SignalRWebUI.Dtos.AboutDtos;
using SignalRWebUI.ViewModels;

namespace SignalRWebUI.Mapping
{
    public class AboutMapping : Profile
    {
        public AboutMapping()
        {
            CreateMap<GetAboutDto, AboutViewModel>();
            CreateMap<AboutViewModel, UpdateAboutDto>();
        }
    }
}
