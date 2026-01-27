namespace SignalR.DtoLayer.ContactDtos
{
    public class UpdateContactDto
    {
        public required string Location { get; set; } 
        public required string Phone { get; set; } 
        public required string Mail { get; set; }
        public string FooterDescription { get; set; } = null!;
        public string FooterTitle { get; set; } = null!;

        public string OpenDays { get; set; } = null!;
        public string OpenDaysDescription { get; set; } = null!;
        public string OpenHours { get; set; } = null!;
    }
}
