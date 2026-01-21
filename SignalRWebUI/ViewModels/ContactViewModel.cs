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
    }
}
