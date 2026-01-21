using System.ComponentModel.DataAnnotations;

namespace SignalRWebUI.ViewModels
{
    public class BookingViewModel
    {
        public int? BookingID { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]

        public string Phone { get; set; } = string.Empty;
        [Required]

        public string Mail { get; set; } = string.Empty;
        [Required]

        public int PersonCount { get; set; }
        [Required]

        public DateTime Date { get; set; }
    }
}
