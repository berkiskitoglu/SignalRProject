namespace SignalR.DtoLayer.BookingDtos
{
    public class UpdateBookingDto
    {
        public required string Name { get; set; }
        public required string Phone { get; set; }
        public required string Mail { get; set; }
        public int PersonCount { get; set; }
        public DateTime Date { get; set; }
    }
}
