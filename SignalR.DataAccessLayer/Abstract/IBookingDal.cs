using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.Abstract
{
    public interface IBookingDal : IGenericDal<Booking>
    {
        Task BookingStatusApproved(int id);
        Task BookingStatusCancelled(int id);
    }
}
