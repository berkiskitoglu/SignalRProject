using System.ComponentModel.DataAnnotations;

namespace SignalRWebUI.ViewModels
{
    public class ContactViewModel
    {
        public int? ContactID { get; set; }
        [Required]
        public string Location { get; set; } = string.Empty;
        [Required]
        public string Phone { get; set; } = string.Empty;
        [Required]
        public string Mail { get; set; } = string.Empty;
        [Required]
        public string FooterDescription { get; set; } = string.Empty;
        [Required]
        public string FooterTitle { get; set; } = string.Empty;
        [Required]
        public string OpenDays { get; set; } = string.Empty;
        [Required]
        public string OpenDaysDescription { get; set; } = string.Empty;
        [Required]
        public string OpenHours { get; set; } = string.Empty;
    }
}
