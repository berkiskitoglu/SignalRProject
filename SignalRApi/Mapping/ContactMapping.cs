using AutoMapper;
using SignalR.DtoLayer.ContactDtos;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Mapping
{
    public class ContactMapping : Profile
    {
        public ContactMapping()
        {
            CreateMap<Contact, ResultContactDto>();
            CreateMap<Contact, GetContactDto>();

            CreateMap<CreateContactDto, Contact>();
            CreateMap<UpdateContactDto, Contact>();
        }
    }
}
