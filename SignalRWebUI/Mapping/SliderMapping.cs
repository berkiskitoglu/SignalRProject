using AutoMapper;
using SignalRWebUI.Dtos.SliderDtos;
using SignalRWebUI.ViewModels;

namespace SignalRWebUI.Mapping
{
    public class SliderMapping : Profile
    {
        public SliderMapping()
        {
            CreateMap<ResultSliderDto, SliderViewModel>();
            CreateMap<GetSliderDto, UpdateSliderDto>();
        }
    }
}
