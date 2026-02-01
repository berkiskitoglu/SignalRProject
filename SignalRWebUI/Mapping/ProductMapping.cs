using AutoMapper;
using SignalRWebUI.Dtos.ProductDtos;
using SignalRWebUI.ViewModels;

namespace SignalRWebUI.Mapping
{
    public class ProductMapping : Profile
    {
        public ProductMapping()
        {
            CreateMap<GetProductDto, ProductViewModel>();

            CreateMap<ProductViewModel, CreateProductDto>();
            CreateMap<ProductViewModel, UpdateProductDto>();
        }
    }
}
