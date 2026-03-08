using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.Abstract
{
    public interface IBasketDal : IGenericDal<Basket>
    {
        Task<List<Basket>> GetBasketByMenuTableNumber(int id);
    }
}
