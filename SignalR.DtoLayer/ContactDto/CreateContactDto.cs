namespace SignalR.DtoLayer.ContactDto
{
    public class CreateContactDto
    {
        public required string Location { get; set; }
        public required string Phone { get; set; }
        public required string Mail { get; set; }
        public required string FooterDescription { get; set; }
    }
}
