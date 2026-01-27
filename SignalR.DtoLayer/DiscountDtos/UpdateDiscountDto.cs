namespace SignalR.DtoLayer.DiscountDtos
{
    public class UpdateDiscountDto
    {
        public required string Title { get; set; } 
        public required int Amount { get; set; }
        public required string Description { get; set; } 
        public required string ImageUrl { get; set; }
    }
}
