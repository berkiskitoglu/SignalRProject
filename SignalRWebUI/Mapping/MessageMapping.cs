using AutoMapper;
using SignalRWebUI.Dtos.MessageDtos;
using SignalRWebUI.ViewModels;

namespace SignalRWebUI.Mapping
{
    public class MessageMapping : Profile
    {
        public MessageMapping()
        {
            CreateMap<GetMessageDto, MessageViewModel>();
            CreateMap<MessageViewModel, UpdateMessageDto>();
            CreateMap<MessageViewModel, CreateMessageDto>();
        }
    }
}
