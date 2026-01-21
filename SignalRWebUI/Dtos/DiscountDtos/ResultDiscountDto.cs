namespace SignalRWebUI.Dtos.DiscountDtos
{
    public class ResultDiscountDto
    {
        public int DiscountID { get; set; }
        public string Title { get; set; } = null!;
        public int Amount { get; set; }
        public string Description { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
    }
}
