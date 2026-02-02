using AutoMapper;
using SignalRWebUI.Dtos.MenuTableDtos;
using SignalRWebUI.ViewModels;

namespace SignalRWebUI.Mapping
{
    public class MenuTableMapping : Profile
    {
        public MenuTableMapping()
        {

            CreateMap<GetMenuTableDto, MenuTableViewModel>();
            CreateMap<MenuTableViewModel, UpdateMenuTableDto>();
            CreateMap<MenuTableViewModel, CreateMenuTableDto>();
        }
    }
}
