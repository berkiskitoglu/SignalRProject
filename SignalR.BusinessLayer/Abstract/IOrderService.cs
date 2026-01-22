using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Abstract
{
    public interface IOrderService : IGenericService<Order>
    {
        Task<int> TTotalOrderCount();
        Task<int> TActiveOrderCount();
        Task<decimal> TLastOrderPrice();

    }
}
