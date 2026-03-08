namespace SignalRWebUI.ViewModels.DiscountViewModels
{
    public class ResultDiscountViewModel
    {
        public int DiscountID { get; set; }
        public string Title { get; set; } = string.Empty;
        public int Amount { get; set; }
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public bool Status { get; set; }
    }
}