using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Concrete
{
    public class OrderManager : IOrderService
    {
        private readonly IOrderDal _orderDal;

        public OrderManager(IOrderDal OrderDal)
        {
            _orderDal = OrderDal;
        }

        public async Task TAddAsync(Order entity) => await _orderDal.AddAsync(entity);

        public async Task TDeleteAsync(Order entity) => await _orderDal.DeleteAsync(entity);

        public async Task TUpdateAsync(Order entity) => await _orderDal.UpdateAsync(entity);

        public async Task<Order?> TGetByIDAsync(int id) => await _orderDal.GetByIDAsync(id);

        public async Task<List<Order>> TGetListAllAsync() => await _orderDal.GetListAllAsync();

        public async Task<int> TTotalOrderCount() => await _orderDal.TotalOrderCount();

        public async Task<int> TActiveOrderCount() => await _orderDal.ActiveOrderCount();

        public async Task<decimal> TLastOrderPrice() => await _orderDal.LastOrderPrice();

        public async Task<decimal> TTodayTotalPrice() => await _orderDal.TodayTotalPrice();
    }
}
