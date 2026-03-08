namespace SignalRWebUI.ViewModels.NotificationViewModels
{
    public class ResultNotificationViewModel
    {
        public int NotificationID { get; set; }
        public string Type { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Icon { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public bool Status { get; set; }
    }
}