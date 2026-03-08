using AutoMapper;
using SignalRWebUI.Dtos.AboutDtos;
using SignalRWebUI.ViewModels.AboutViewModels;

namespace SignalRWebUI.Mapping
{
    public class AboutMapping : Profile
    {
        public AboutMapping()
        {
            CreateMap<ResultAboutDto, ResultAboutViewModel>();
            CreateMap<GetAboutDto, UpdateAboutViewModel>();
            CreateMap<CreateAboutViewModel, CreateAboutDto>();
            CreateMap<UpdateAboutViewModel, UpdateAboutDto>();
        }
    }
}