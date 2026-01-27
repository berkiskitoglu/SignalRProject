namespace SignalR.DtoLayer.ProductDtos
{
    public class ResultProductWithCategory
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; } = null!;
        public bool ProductStatus { get; set; }
        public string CategoryName { get; set; } = null!;
    }
}
