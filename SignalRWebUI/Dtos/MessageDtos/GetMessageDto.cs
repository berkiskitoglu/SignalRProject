namespace SignalR.DtoLayer.MessageDtos
{
    public class GetMessageDto
    {
        public int MessageID { get; set; }
        public required string NameSurname { get; set; }
        public required string Mail { get; set; }
        public required string Phone { get; set; }
        public required string Subject { get; set; }
        public required string MessageContent { get; set; }
        public DateTime MessageSendDate { get; set; }
        public bool Status { get; set; }
    }
}
