using SignalRWebUI.Dtos.BookingDtos;

namespace SignalRWebUI.Services.Abstract
{
    public interface IBookingApiService : IGenericApiService<ResultBookingDto,CreateBookingDto,UpdateBookingDto,GetBookingDto>
    {
        Task BookingStatusApproved(int id);
        Task BookingStatusCancelled(int id);
    }
}
