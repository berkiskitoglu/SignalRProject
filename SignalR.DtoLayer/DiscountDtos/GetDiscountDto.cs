namespace SignalR.DtoLayer.DiscountDtos
{
    public class GetDiscountDto
    {
        public int DiscountID { get; set; }
        public string? Title { get; set; }
        public int Amount { get; set; }
        public string? Description { get; set; }
        public bool Status { get; set; }
        public string? ImageUrl { get; set; }
    }
}