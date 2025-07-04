using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Concrete
{
    public class OrderManager : IOrderService
    {
        public readonly IOrderDal _orderDal;

        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }

        public void TAdd(Order entity)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Order entity)
        {
            throw new NotImplementedException();
        }

        public int TGetActiveOrderCount()
        {
            return _orderDal.GetActiveOrderCount();
        }

        public Order TGetByID(int id)
        {
            throw new NotImplementedException();
        }

        public decimal TGetLastOrderPrice()
        {
            return _orderDal.GetLastOrderPrice();
        }

        public List<Order> TGetListAll()
        {
            throw new NotImplementedException();
        }

        public int TGetTotalOrderCount()
        {
            return _orderDal.GetTotalOrderCount();
        }

        public decimal TTodayTotalPrice()
        {
            return _orderDal.TodayTotalPrice();
        }

        public void TUpdate(Order entity)
        {
            throw new NotImplementedException();
        }
    }
}
