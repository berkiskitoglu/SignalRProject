using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Abstract
{
    public interface IBasketProductService : IGenericService<BasketProduct>
    {
        Task<List<BasketProduct>> TGetBasketProductsByBasketIdAsync(int basketId);
        Task<BasketProduct> TGetByBasketAndProductIdAsync(int basketId, int productId);

    }
}
