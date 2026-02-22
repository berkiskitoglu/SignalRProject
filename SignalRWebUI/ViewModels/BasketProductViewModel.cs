using System.ComponentModel.DataAnnotations;

namespace SignalRWebUI.ViewModels
{
    public class BasketProductViewModel
    {
        public int ProductID { get; set; }

        public string ProductName { get; set; } = string.Empty;

        public decimal Price { get; set; }

        [Required(ErrorMessage = "Miktar zorunludur")]
        [Range(1, 1000,
            ErrorMessage = "Miktar 1 ile 1000 arasında olmalıdır")]
        [Display(Name = "Miktar")]
        public int Quantity { get; set; }

        [Display(Name = "Toplam Fiyat")]
        public decimal TotalPrice => Price * Quantity;
    }
}