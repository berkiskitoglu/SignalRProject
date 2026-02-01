using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
