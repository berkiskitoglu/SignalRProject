using Microsoft.EntityFrameworkCore;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;
using System;


namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EfOrderDal : GenericRepository<Order>, IOrderDal
    {
        public EfOrderDal(SignalRContext context) : base(context)
        {
        }

        public async Task<int> ActiveOrderCount() => await _context.Orders.Where(x => x.Description == "Müşteri Masada").CountAsync();

        public async Task<decimal> LastOrderPrice() => await _context.Orders.OrderByDescending(x => x.Date).Select(y => y.TotalPrice).FirstAsync();

        public async Task<int> TotalOrderCount() => await _context.Orders.CountAsync();

        public async Task<decimal> TodayTotalPrice()
        {
            DateTime start = DateTime.Today;
            DateTime end = start.AddDays(1);
            return await _context.Orders.Where(x => x.Date >= start && x.Date < end).SumAsync(o => o.TotalPrice);
        }

    }
}
