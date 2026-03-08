namespace SignalRWebUI.ViewModels.ProductViewModels
{
    public class ResultProductViewModel
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public bool ProductStatus { get; set; }
        public string CategoryName { get; set; } = string.Empty;
    }
}