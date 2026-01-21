using System.ComponentModel.DataAnnotations;

namespace SignalRWebUI.ViewModels
{
    public class FeatureViewModel
    {
        public int? FeatureID { get; set; }

        [Required]
        public string Title1 { get; set; } = string.Empty;

        [Required]
        public string Description1 { get; set; } = string.Empty;

        [Required]
        public string Title2 { get; set; } = string.Empty;

        [Required]
        public string Description2 { get; set; } = string.Empty;

        [Required]
        public string Title3 { get; set; } = string.Empty;

        [Required]
        public string Description3 { get; set; } = string.Empty;
    }
}
