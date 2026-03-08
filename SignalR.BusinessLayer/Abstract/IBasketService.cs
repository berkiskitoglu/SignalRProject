using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Abstract
{
    public interface IBasketService : IGenericService<Basket>
    {
        Task<List<Basket>> TGetBasketByMenuTableNumber(int id);

    }
}
