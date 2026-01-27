using AutoMapper;
using SignalR.DtoLayer.BasketProductDtos;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Mapping
{
    public class BasketProductMapping : Profile
    {
        public BasketProductMapping()
        {
            CreateMap<ResultBasketProductDto, BasketProduct>();

            CreateMap<CreateBasketProductDto, BasketProduct>();
 
        }
    }
}
