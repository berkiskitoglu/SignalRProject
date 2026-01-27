using AutoMapper;
using SignalR.DtoLayer.AboutDtos;
using SignalR.DtoLayer.BasketDtos;
using SignalR.DtoLayer.BasketProductDtos;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Mapping
{
    public class BasketMapping : Profile
    {
        public BasketMapping()
        {
            CreateMap<BasketProduct, ResultBasketProductDto>()
            .ForMember(dest => dest.ProductID, opt => opt.MapFrom(src => src.Product.ProductID))
            .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.ProductName))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Product.Price))
            .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => src.TotalPrice))
            .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity));

            CreateMap<Basket, ResultBasketDto>()
                .ForMember(dest => dest.Products,
                    opt => opt.MapFrom(src => src.BasketProducts));


            CreateMap<CreateBasketDto, Basket>();
    

        }
    }
}
