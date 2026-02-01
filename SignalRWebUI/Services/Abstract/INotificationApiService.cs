using SignalRWebUI.Dtos.NotificationDtos;

namespace SignalRWebUI.Services.Abstract
{
    public interface INotificationApiService : IGenericApiService<ResultNotificationDto, CreateNotificationDto, UpdateNotificationDto , GetNotificationDto>
    {
        Task NotificationStatusChangeToTrue(int id);
        Task NotificationStatusChangeToFalse(int id);
    }
}
