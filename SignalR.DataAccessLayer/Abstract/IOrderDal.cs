using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.Abstract
{
    public interface IOrderDal : IGenericDal<Order>
    {
        Task<int> TotalOrderCount();
        Task<int> ActiveOrderCount();
        Task<decimal> LastOrderPrice();
    }
}
