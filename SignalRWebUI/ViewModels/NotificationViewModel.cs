namespace SignalRWebUI.ViewModels
{
    public class NotificationViewModel
    {
        public int NotificationID { get; set; }
        public string Type { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Icon { get; set; } = null!;
        public DateTime Date { get; set; }
        public bool Status { get; set; }
    }
}
