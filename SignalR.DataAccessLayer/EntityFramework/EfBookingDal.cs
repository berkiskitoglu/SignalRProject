using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EfBookingDal : GenericRepository<Booking>, IBookingDal
    {
        public EfBookingDal(SignalRContext context) : base(context)
        {
        }

        public async Task BookingStatusApproved(int id)
        {
            var values = await _context.Bookings.FindAsync(id);
            values.Description = "Rezervasyon Onaylandı";
            await _context.SaveChangesAsync();
        }

        public async Task BookingStatusCancelled(int id)
        {
            var values = await _context.Bookings.FindAsync(id);
            values.Description = "Rezervasyon İptal Edildi";
            await _context.SaveChangesAsync();
        }
    }
}
