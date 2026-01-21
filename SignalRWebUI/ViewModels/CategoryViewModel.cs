using System.ComponentModel.DataAnnotations;

namespace SignalRWebUI.ViewModels
{
    public class CategoryViewModel
    {
        public int? CategoryID { get; set; }
        [Required]
        public string CategoryName { get; set; } = string.Empty;
        [Required]
        public bool Status { get; set; }
    }
}
