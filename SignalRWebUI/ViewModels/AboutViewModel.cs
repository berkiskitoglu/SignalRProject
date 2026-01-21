using System.ComponentModel.DataAnnotations;

namespace SignalRWebUI.ViewModels
{
    public class AboutViewModel
    {
        public int? AboutID { get; set; }
        [Required]
        public string ImageUrl { get; set; } = string.Empty;
        [Required]

        public string Title { get; set; } = string.Empty;
        [Required]

        public string Description { get; set; } = string.Empty;
    }
}
