namespace SignalRWebUI.ViewModels
{
    public class DiscountViewModel
    {
        public int DiscountID { get; set; }
        public string Title { get; set; } = string.Empty;
        public int Amount { get; set; }
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public bool Status { get; set; }
    }
}