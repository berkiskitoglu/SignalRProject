using AutoMapper;
using SignalRWebUI.Dtos.ProductDtos;
using SignalRWebUI.ViewModels.ProductViewModels;

namespace SignalRWebUI.Mapping
{
    public class ProductMapping : Profile
    {
        public ProductMapping()
        {
            CreateMap<ResultProductWithCategoryDto, ResultProductViewModel>();
            CreateMap<GetProductDto, UpdateProductViewModel>();
            CreateMap<CreateProductViewModel, CreateProductDto>();
            CreateMap<UpdateProductViewModel, UpdateProductDto>();
        }
    }
}