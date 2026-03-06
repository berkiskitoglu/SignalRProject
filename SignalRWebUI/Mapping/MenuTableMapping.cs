using AutoMapper;
using SignalRWebUI.Dtos.MenuTableDtos;
using SignalRWebUI.ViewModels;

namespace SignalRWebUI.Mapping
{
    public class MenuTableMapping : Profile
    {
        public MenuTableMapping()
        {

            CreateMap<ResultMenuTableDto, MenuTableViewModel>();
            CreateMap<GetMenuTableDto, UpdateMenuTableDto>();
        }
    }
}
