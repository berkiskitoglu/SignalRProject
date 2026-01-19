using AutoMapper;
using SignalRWebUI.Dtos.CategoryDtos;
using SignalRWebUI.ViewModels.CategoryViewModel;

namespace SignalRWebUI.Mapping
{
    public class CategoryMapping : Profile
    {
        public CategoryMapping()
        {
            // GET için: DTO → ViewModel
            CreateMap<GetCategoryDto, UpdateCategoryViewModel>();

            // POST için: ViewModel → DTO
            CreateMap<UpdateCategoryViewModel, UpdateCategoryDto>();

        }
    }
}
