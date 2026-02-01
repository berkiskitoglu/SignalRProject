using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
