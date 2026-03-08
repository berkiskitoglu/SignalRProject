using AutoMapper;
using SignalRWebUI.Dtos.ContactDtos;
using SignalRWebUI.ViewModels.ContactViewModels;

namespace SignalRWebUI.Mapping
{
    public class ContactMapping : Profile
    {
        public ContactMapping()
        {
            CreateMap<ResultContactDto, ResultContactViewModel>();
            CreateMap<GetContactDto, UpdateContactViewModel>();
            CreateMap<CreateContactViewModel, CreateContactDto>();
            CreateMap<UpdateContactViewModel, UpdateContactDto>();
        }
    }
}