using SignalRWebUI.Dtos.MessageDtos;

namespace SignalRWebUI.Services.Abstract
{
    public interface IMessageApiService : IGenericApiService<ResultMessageDto,CreateMessageDto,UpdateMessageDto,GetMessageDto>
    {
    }
}
