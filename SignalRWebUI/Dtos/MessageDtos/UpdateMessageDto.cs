namespace SignalRWebUI.Dtos.MessageDtos
{
    public class UpdateMessageDto
    {
        public required string NameSurname { get; set; }
        public required string Mail { get; set; }
        public required string Phone { get; set; }
        public required string Subject { get; set; }
        public required string MessageContent { get; set; }
        public DateTime MessageSendDate { get; set; }
        public bool Status { get; set; }
    }
}
