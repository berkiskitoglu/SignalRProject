using System.ComponentModel.DataAnnotations;

namespace SignalRWebUI.ViewModels
{
    public class DiscountViewModel
    {
        public int? DiscountID { get; set; }
        [Required]
        public string Title { get; set; } = string.Empty;
        [Required]

        public int Amount { get; set; }
        [Required]

        public string Description { get; set; } = string.Empty;
        [Required]

        public string ImageUrl { get; set; } = string.Empty;
    }
}
