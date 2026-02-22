namespace SignalRWebUI.Dtos.NotificationDtos
{
    public class UpdateNotificationDto
    {
        public string? Type { get; set; } 
        public string? Description { get; set; } 
        public string? Icon { get; set; } 
        public DateTime Date { get; set; }
        public bool Status { get; set; }
    }
}
