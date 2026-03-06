namespace SignalRWebUI.ViewModels
{
    public class ContactViewModel
    {
        public int ContactID { get; set; }
        public string Location { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Mail { get; set; } = string.Empty;
        public string FooterDescription { get; set; } = string.Empty;
        public string FooterTitle { get; set; } = string.Empty;
        public string OpenDays { get; set; } = string.Empty;
        public string OpenDaysDescription { get; set; } = string.Empty;
        public string OpenHours { get; set; } = string.Empty;
    }
}