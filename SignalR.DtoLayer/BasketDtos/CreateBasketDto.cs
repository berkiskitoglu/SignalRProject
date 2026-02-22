using SignalR.DtoLayer.BasketProductDtos;

namespace SignalR.DtoLayer.BasketDtos
{
    public class CreateBasketDto
    {
        public required string Status { get; set; }
        public int MenuTableID { get; set; }
        public required List<CreateBasketProductDto> Products { get; set; }

    }
}
