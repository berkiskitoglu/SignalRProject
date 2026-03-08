using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.Abstract
{
    public interface IBasketProductDal : IGenericDal<BasketProduct>
    {
        Task<List<BasketProduct>> GetBasketProductsByBasketIdAsync(int basketId);
        Task<BasketProduct> GetByBasketAndProductIdAsync(int basketId, int productId);

    }
}
