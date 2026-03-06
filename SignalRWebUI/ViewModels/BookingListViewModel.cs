using SignalRWebUI.Dtos.BookingDtos;

namespace SignalRWebUI.ViewModels
{
    public class BookingListViewModel
    {
        public string SignalRUrl { get; set; } = string.Empty;
        public List<ResultBookingDto> Bookings { get; set; } = new();
    }
}