using System.ComponentModel.DataAnnotations;

namespace SignalRWebUI.ViewModels
{
    public class SocialMediaViewModel
    {
        public int? SocialMediaID { get; set; }
        [Required]
        public string Title { get; set; } = string.Empty;
        [Required]

        public string Url { get; set; } = string.Empty;
        [Required]

        public string Icon { get; set; } = string.Empty;
    }
}
