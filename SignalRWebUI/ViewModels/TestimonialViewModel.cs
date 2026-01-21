using System.ComponentModel.DataAnnotations;

namespace SignalRWebUI.ViewModels
{
    public class TestimonialViewModel
    {
        public int? TestimonialID { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]

        public string Title { get; set; } = string.Empty;
        [Required]

        public string Comment { get; set; } = string.Empty;
        [Required]

        public string ImageUrl { get; set; } = string.Empty;
        [Required]

        public bool Status { get; set; }
    }
}
