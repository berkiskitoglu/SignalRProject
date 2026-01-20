namespace SignalR.DtoLayer.ProductDto
{
    public class UpdateProductDto
    {
        public required string ProductName { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public required string ImageUrl { get; set; }
        public bool ProductStatus { get; set; }
    }
}
