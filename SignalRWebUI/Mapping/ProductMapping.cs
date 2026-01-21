using AutoMapper;
using SignalRWebUI.Dtos.ProductDtos;
using SignalRWebUI.ViewModels;

namespace SignalRWebUI.Mapping
{
    public class ProductMapping : Profile
    {
        public ProductMapping()
        {
            
            CreateMap<ProductViewModel, CreateProductDto>();
            CreateMap<GetProductDto, ProductViewModel>();
        }
    }
}
