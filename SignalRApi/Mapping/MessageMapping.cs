using AutoMapper;
using SignalR.DtoLayer.MessageDtos;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Mapping
{
    public class MessageMapping : Profile
    {
        public MessageMapping()
        {
            //Read Only DTO (GET / RESULT)
            CreateMap<Message, ResultMessageDto>();
            CreateMap<Message, GetMessageDto>();

            // Write DTO (POST / PUT)
            CreateMap<CreateMessageDto, Message>();
            CreateMap<UpdateMessageDto, Message>();
        }
    }
}
