using AutoMapper;
using SignalRWebUI.Dtos.DiscountDtos;
using SignalRWebUI.ViewModels;

namespace SignalRWebUI.Mapping
{
    public class DiscountMapping : Profile
    {
        public DiscountMapping()
        {
            CreateMap<ResultDiscountDto, DiscountViewModel>();
            CreateMap<GetDiscountDto, UpdateDiscountDto>();
        }
    }
}
