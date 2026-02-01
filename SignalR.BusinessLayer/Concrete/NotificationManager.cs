using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.EntityFramework;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Concrete
{
    public class NotificationManager : INotificationService
    {
        private readonly INotificationDal _notificationDal;

        public NotificationManager(INotificationDal notificationDal)
        {
            _notificationDal = notificationDal;
        }

        public async Task TAddAsync(Notification entity) => await _notificationDal.AddAsync(entity);

        public async Task TUpdateAsync(Notification entity) => await _notificationDal.UpdateAsync(entity);

        public async Task TDeleteAsync(Notification entity) => await _notificationDal.DeleteAsync(entity);

        public async Task<Notification?> TGetByIDAsync(int id) => await _notificationDal.GetByIDAsync(id);

        public async Task<List<Notification>> TGetListAllAsync() => await _notificationDal.GetListAllAsync();

        public async Task<int> TGetUnreadNotificationCountAsync() => await _notificationDal.GetUnreadNotificationCountAsync();

        public async Task<List<Notification>> TGetlAllUnreadNotificationAsync() => await _notificationDal.GetlAllUnreadNotificationAsync();

        public async Task TNotificationChangeToTrue(int id) => await _notificationDal.NotificationChangeToTrue(id);

        public async Task TNotificationChangeToFalse(int id) => await _notificationDal.NotificationChangeToFalse(id);

    }
}
