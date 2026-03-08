using AutoMapper;
using SignalRWebUI.Dtos.MenuTableDtos;
using SignalRWebUI.ViewModels.MenuTableViewModels;

namespace SignalRWebUI.Mapping
{
    public class MenuTableMapping : Profile
    {
        public MenuTableMapping()
        {
            CreateMap<ResultMenuTableDto, ResultMenuTableViewModel>();
            CreateMap<GetMenuTableDto, UpdateMenuTableViewModel>();
            CreateMap<CreateMenuTableViewModel, CreateMenuTableDto>();
            CreateMap<UpdateMenuTableViewModel, UpdateMenuTableDto>();
        }
    }
}