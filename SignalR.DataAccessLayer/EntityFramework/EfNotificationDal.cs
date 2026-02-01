using Microsoft.EntityFrameworkCore;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EfNotificationDal : GenericRepository<Notification>, INotificationDal
    {
        public EfNotificationDal(SignalRContext context) : base(context)
        {
        }

        public async Task<List<Notification>> GetlAllUnreadNotificationAsync() => await _context.Notifications.Where(x => x.Status == false).ToListAsync();


        public async Task<int> GetUnreadNotificationCountAsync() => await _context.Notifications.Where(x => x.Status == false).CountAsync();

        public async Task NotificationChangeToFalse(int id)
        {
            var value = await _context.Notifications.FindAsync(id);
            if(value == null)
                throw new Exception("Bildirim Bulunamadı");
            value.Status = false;
           await _context.SaveChangesAsync();
        }


        public async Task NotificationChangeToTrue(int id)
        {
            var value = await _context.Notifications.FindAsync(id);
            if (value == null)
                throw new Exception("Bildirim Bulunamadı");
            value.Status = true;
            await _context.SaveChangesAsync();
        }
    }
}
