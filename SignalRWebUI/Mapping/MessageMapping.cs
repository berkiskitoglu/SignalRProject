using AutoMapper;
using SignalRWebUI.Dtos.MessageDtos;
using SignalRWebUI.ViewModels.MessageViewModels;

namespace SignalRWebUI.Mapping
{
    public class MessageMapping : Profile
    {
        public MessageMapping()
        {
            CreateMap<GetMessageDto, ResultMessageViewModel>();
            CreateMap<ResultMessageViewModel, UpdateMessageDto>();
            CreateMap<ResultMessageViewModel, CreateMessageDto>();
        }
    }
}
