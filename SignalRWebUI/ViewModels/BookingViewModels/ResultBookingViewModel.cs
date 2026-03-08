namespace SignalRWebUI.ViewModels.BookingViewModels
{
    public class ResultBookingViewModel
    {
        public int BookingID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Mail { get; set; } = string.Empty;
        public int PersonCount { get; set; }
        public DateTime Date { get; set; }
    }
}