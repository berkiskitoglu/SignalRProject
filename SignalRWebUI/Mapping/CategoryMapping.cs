using AutoMapper;
using SignalRWebUI.Dtos.CategoryDtos;
using SignalRWebUI.ViewModels;

namespace SignalRWebUI.Mapping
{
    public class CategoryMapping : Profile
    {
        public CategoryMapping()
        {
            CreateMap<ResultCategoryDto, CategoryViewModel>();
            CreateMap<GetCategoryDto, UpdateCategoryDto>();

        }
    }
}
