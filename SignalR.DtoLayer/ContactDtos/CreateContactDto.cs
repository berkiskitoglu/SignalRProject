namespace SignalR.DtoLayer.ContactDtos
{
    public class CreateContactDto
    {
        public required string Location { get; set; }
        public required string Phone { get; set; }
        public required string Mail { get; set; }
        public required string FooterTitle { get; set; } 

        public required string FooterDescription { get; set; } 
        public required string OpenDays { get; set; } 
        public required string OpenDaysDescription { get; set; } 
        public required string OpenHours { get; set; } 
    }
}
