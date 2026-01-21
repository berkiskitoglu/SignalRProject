using AutoMapper;
using SignalRWebUI.Dtos.CategoryDtos;
using SignalRWebUI.ViewModels;

namespace SignalRWebUI.Mapping
{
    public class CategoryMapping : Profile
    {
        public CategoryMapping()
        {
            // GET için: DTO → ViewModel
            CreateMap<GetCategoryDto, CategoryViewModel>();

            // POST için: ViewModel → DTO
            CreateMap<CategoryViewModel, UpdateCategoryDto>();

             // Create => Viewmodel => Dto
            CreateMap<CategoryViewModel, CreateCategoryDto>();

        }
    }
}
