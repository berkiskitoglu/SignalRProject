using AutoMapper;
using SignalRWebUI.Dtos.CategoryDtos;
using SignalRWebUI.ViewModels;
using SignalRWebUI.ViewModels.CategoryViewModels;

namespace SignalRWebUI.Mapping
{
    public class CategoryMapping : Profile
    {
        public CategoryMapping()
        {
            CreateMap<ResultCategoryDto, ResultCategoryViewModel>();
            CreateMap<GetCategoryDto, UpdateCategoryViewModel>();
            CreateMap<CreateCategoryViewModel, CreateCategoryDto>();
            CreateMap<UpdateCategoryViewModel, UpdateCategoryDto>();

        }
    }
}
