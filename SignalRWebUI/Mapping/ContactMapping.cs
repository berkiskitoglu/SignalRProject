using AutoMapper;
using SignalRWebUI.Dtos.ContactDtos;
using SignalRWebUI.ViewModels;

namespace SignalRWebUI.Mapping
{
    public class ContactMapping : Profile
    {
        public ContactMapping()
        {
            CreateMap<ResultContactDto, ContactViewModel>();
            CreateMap<GetContactDto, UpdateContactDto>();
        }
    }
}
