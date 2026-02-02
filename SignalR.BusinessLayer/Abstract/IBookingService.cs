using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Abstract
{
    public interface IBookingService : IGenericService<Booking>
    {
        Task TBookingStatusApproved(int id);
        Task TBookingStatusCancelled(int id);
    }
}
