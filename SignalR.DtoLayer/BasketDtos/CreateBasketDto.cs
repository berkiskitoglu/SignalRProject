using SignalR.DtoLayer.BasketProductDtos;

namespace SignalR.DtoLayer.BasketDtos
{
    public class CreateBasketDto
    {
        public string Status { get; set; }
        public int MenuTableID { get; set; }
        public List<CreateBasketProductDto> Products { get; set; }

    }
}
