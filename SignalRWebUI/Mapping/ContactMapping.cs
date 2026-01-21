using AutoMapper;
using SignalRWebUI.Dtos.ContactDtos;
using SignalRWebUI.ViewModels;

namespace SignalRWebUI.Mapping
{
    public class ContactMapping : Profile
    {
        public ContactMapping()
        {
            CreateMap<GetContactDto, ContactViewModel>();
            CreateMap<ContactViewModel, CreateContactDto>();
            CreateMap<ContactViewModel, UpdateContactDto>();
        }
    }
}
