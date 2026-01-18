namespace SignalR.DtoLayer.ContactDto
{
    public class UpdateContactDto
    {
        public int ContactID { get; set; }
        public required string Location { get; set; } 
        public required string Phone { get; set; } 
        public required string Mail { get; set; } 
        public required string FooterDescription { get; set; }
    }
}
