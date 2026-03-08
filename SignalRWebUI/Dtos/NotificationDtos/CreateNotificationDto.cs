namespace SignalRWebUI.Dtos.NotificationDtos
{
    public class CreateNotificationDto
    {
        public string? Type { get; set; }
        public string? Description { get; set; }
        public string? Icon { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public bool Status { get; set; }
    }
}