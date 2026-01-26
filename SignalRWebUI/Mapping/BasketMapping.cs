using AutoMapper;
using SignalRWebUI.Dtos.BasketDtos;
using SignalRWebUI.Dtos.ProductDtos;
using SignalRWebUI.ViewModels;

namespace SignalRWebUI.Mapping
{
    public class BasketMapping : Profile
    {
        public BasketMapping()
        {
            // 1️⃣ ÜRÜN mapping (OLMAZSA OLMAZ)
            CreateMap<ResultBasketProductDto, BasketProductViewModel>();


            // 2️⃣ SEPET mapping
            CreateMap<ResultBasketDto, BasketViewModel>();
   
        }
    }
}
