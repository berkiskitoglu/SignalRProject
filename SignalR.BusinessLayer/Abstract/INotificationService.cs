using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Abstract
{
    public interface INotificationService : IGenericService<Notification>
    {
        Task<int> TGetUnreadNotificationCountAsync();
        Task<List<Notification>> TGetlAllUnreadNotificationAsync();
        Task TNotificationChangeToTrue(int id);
        Task TNotificationChangeToFalse(int id);

    }
}
