using AutoMapper;
using SignalR.DtoLayer.SliderDtos;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Mapping
{
    public class FeatureMapping : Profile
    {
        public FeatureMapping()
        {
            CreateMap<Slider, ResultSliderDto>();
            CreateMap<Slider, GetSliderDto>();

            CreateMap<CreateSliderDto, Slider>();
            CreateMap<UpdateSliderDto, Slider>();
        }
    }
}
