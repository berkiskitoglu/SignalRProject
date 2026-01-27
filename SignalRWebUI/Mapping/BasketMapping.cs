using AutoMapper;
using NuGet.ContentModel;
using SignalRWebUI.Dtos.BasketDtos;
using SignalRWebUI.Dtos.BasketProductDtos;
using SignalRWebUI.Dtos.ProductDtos;
using SignalRWebUI.ViewModels;

namespace SignalRWebUI.Mapping
{
    public class BasketMapping : Profile
    {
        public BasketMapping()
        {
            CreateMap<ResultBasketProductDto, BasketProductViewModel>();
            CreateMap<ResultBasketDto, BasketViewModel>();

            CreateMap<ResultBasketProductDto, BasketViewModel>();
            CreateMap<CreateBasketViewModel, CreateBasketDto>();
            CreateMap<CreateBasketProductViewModel, CreateBasketProductDto>();
            CreateMap<BasketProductViewModel, CreateBasketProductDto>();
        }
    }
}
