namespace SignalRWebUI.Dtos.BookingDtos
{
    public class UpdateBookingDto
    {
        public string Name { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Mail { get; set; } = null!;
        public int PersonCount { get; set; }
        public DateTime Date { get; set; }
    }
}
