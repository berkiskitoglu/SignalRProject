using SignalRWebUI.Dtos.BasketProductDtos;
using SignalRWebUI.ViewModels;

namespace SignalRWebUI.Dtos.BasketDtos
{
    public class CreateBasketDto
    {
        public int BasketID { get; set; }
        public int MenuTableID { get; set; }
        public string Status { get; set; }
        public List<CreateBasketProductDto> Products { get; set; }

    }
}
