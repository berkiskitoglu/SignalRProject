using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Concrete
{
    public class OrderDetailManager : IOrderDetailService
    {
        private readonly IOrderDetailDal _orderDetailDal;

        public OrderDetailManager(IOrderDetailDal orderDetailDal)
        {
            _orderDetailDal = orderDetailDal;
        }

        public async Task TAddAsync(OrderDetail entity) => await _orderDetailDal.AddAsync(entity);

        public async Task TDeleteAsync(OrderDetail entity) => await _orderDetailDal.DeleteAsync(entity);

        public async Task TUpdateAsync(OrderDetail entity) => await _orderDetailDal.UpdateAsync(entity);

        public async Task<OrderDetail?> TGetByIDAsync(int id) => await _orderDetailDal.GetByIDAsync(id);

        public async Task<List<OrderDetail>> TGetListAllAsync() => await _orderDetailDal.GetListAllAsync();
    }
}
