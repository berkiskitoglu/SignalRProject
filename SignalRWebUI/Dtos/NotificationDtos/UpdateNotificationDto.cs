namespace SignalRWebUI.Dtos.NotificationDtos
{
    public class UpdateNotificationDto
    {
        public string Type { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Icon { get; set; } = null!;
        public DateTime Date { get; set; }
        public bool Status { get; set; }
    }
}
