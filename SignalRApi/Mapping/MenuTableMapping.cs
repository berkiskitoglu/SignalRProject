using AutoMapper;
using SignalR.DtoLayer.MenuTableDtos;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Mapping
{
    public class MenuTableMapping : Profile
    {
        public MenuTableMapping()
        {
            //Read Only DTO (GET / RESULT)
            CreateMap<MenuTable, ResultMenuTableDto>();
            CreateMap<MenuTable, GetMenuTableDto>();

            // Write DTO (POST / PUT)
            CreateMap<CreateMenuTableDto, MenuTable>();
            CreateMap<UpdateMenuTableDto, MenuTable>();
        }
    }
}
