using AutoMapper;
using SignalR.DtoLayer.ProductDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Mapping
{
    public class ProductMapping : Profile
    {
        public ProductMapping()
        {
            CreateMap<Product, ResultProductDto>();
            CreateMap<Product, GetProductDto>();
            CreateMap<Product, ResultProductWithCategory>().ForMember(dest => dest.CategoryName,opt =>opt.MapFrom(src => src.Category.CategoryName));

            CreateMap<CreateProductDto, Product>();
            CreateMap<UpdateProductDto, Product>();
        }
    }
}
