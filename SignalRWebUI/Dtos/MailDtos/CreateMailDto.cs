namespace SignalRWebUI.Dtos.MailDtos
{
    public class CreateMailDto
    {
        public required string ReceiverMail { get; set; }
        public required string Subject { get; set; }
        public required string Content { get; set; }
    }
}
