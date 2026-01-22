using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Concrete
{
    public class BookingManager : IBookingService
    {
        private readonly IBookingDal _bookingDal;

        public BookingManager(IBookingDal bookingDal)
        {
            _bookingDal = bookingDal;
        }

        public async Task TAddAsync(Booking entity) => await _bookingDal.AddAsync(entity);

        public async Task TDeleteAsync(Booking entity) => await _bookingDal.DeleteAsync(entity);

        public async Task TUpdateAsync(Booking entity) => await _bookingDal.UpdateAsync(entity);

        public async Task<Booking?> TGetByIDAsync(int id) => await _bookingDal.GetByIDAsync(id);

        public async Task<List<Booking>> TGetListAllAsync() => await _bookingDal.GetListAllAsync();
    }
}