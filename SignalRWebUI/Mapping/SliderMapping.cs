using AutoMapper;
using SignalRWebUI.Dtos.SliderDtos;
using SignalRWebUI.ViewModels.SliderViewModels;

namespace SignalRWebUI.Mapping
{
    public class SliderMapping : Profile
    {
        public SliderMapping()
        {
            CreateMap<ResultSliderDto, ResultSliderViewModel>();
            CreateMap<GetSliderDto, UpdateSliderViewModel>();
            CreateMap<CreateSliderViewModel, CreateSliderDto>();
            CreateMap<UpdateSliderViewModel, UpdateSliderDto>();
        }
    }
}