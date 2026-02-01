using SignalRWebUI.Dtos.BasketProductDtos;

namespace SignalRWebUI.Services.Abstract
{
    public interface IBasketProductApiService
    {
        Task DeleteBasketProduct(int basketId, int productId);

    }
}
