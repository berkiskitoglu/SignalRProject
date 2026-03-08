using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.Abstract
{
    public interface INotificationDal : IGenericDal<Notification>
    {
        Task<int> GetUnreadNotificationCountAsync();
        Task<List<Notification>> GetlAllUnreadNotificationAsync();

        Task  NotificationChangeToTrue(int id);
        Task  NotificationChangeToFalse(int id);
    }
}
