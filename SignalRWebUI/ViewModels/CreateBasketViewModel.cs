using System.ComponentModel.DataAnnotations;

namespace SignalRWebUI.ViewModels
{

    public class CreateBasketViewModel
    {
        public int ProductID { get; set; }

        public string Status { get; set; } = string.Empty;

        public int MenuTableID { get; set; }

        [Display(Name = "Ürünler")]
        public List<BasketProductViewModel> Products { get; set; } = new List<BasketProductViewModel>();
    }
}