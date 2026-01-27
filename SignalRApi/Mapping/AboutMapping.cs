using AutoMapper;
using SignalR.DtoLayer.AboutDtos;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Mapping
{
    public class AboutMapping : Profile
    {
        public AboutMapping()
        {
            //Read Only DTO (GET / RESULT)
            CreateMap<About, ResultAboutDto>();
            CreateMap<About, GetAboutDto>();

            // Write DTO (POST / PUT)
            CreateMap<CreateAboutDto,About>();
            CreateMap<UpdateAboutDto,About>();

        }
    }
}
