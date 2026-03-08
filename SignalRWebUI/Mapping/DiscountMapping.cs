using AutoMapper;
using SignalRWebUI.Dtos.DiscountDtos;
using SignalRWebUI.ViewModels.DiscountViewModels;

namespace SignalRWebUI.Mapping
{
    public class DiscountMapping : Profile
    {
        public DiscountMapping()
        {
            CreateMap<ResultDiscountDto, ResultDiscountViewModel>();
            CreateMap<GetDiscountDto, UpdateDiscountViewModel>();
            CreateMap<CreateDiscountViewModel, CreateDiscountDto>();
            CreateMap<UpdateDiscountViewModel, UpdateDiscountDto>();
        }
    }
}