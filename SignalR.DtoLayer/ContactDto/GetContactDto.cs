namespace SignalR.DtoLayer.ContactDto
{
    public class GetContactDto
    {
        public int ContactID { get; set; }
        public string Location { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Mail { get; set; } = null!;
        public string FooterDescription { get; set; } = null!;
    }
}
