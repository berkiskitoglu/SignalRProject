using AutoMapper;
using SignalRWebUI.Dtos.BasketDtos;
using SignalRWebUI.Dtos.BasketProductDtos;
using SignalRWebUI.ViewModels.BasketViewModels;

namespace SignalRWebUI.Mapping
{
    public class BasketMapping : Profile
    {
        public BasketMapping()
        {
            CreateMap<ResultBasketDto, ResultBasketViewModel>();
            CreateMap<ResultBasketProductDto, ResultBasketProductViewModel>();
            CreateMap<ResultBasketProductViewModel, CreateBasketProductDto>();
            CreateMap<ResultBasketViewModel, CreateBasketDto>();
            CreateMap<CreateBasketViewModel, CreateBasketDto>();
            CreateMap<CreateBasketProductViewModel, CreateBasketProductDto>();
        }
    }
}