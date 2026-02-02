using Microsoft.EntityFrameworkCore;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EfDiscountDal : GenericRepository<Discount>, IDiscountDal
    {
        public EfDiscountDal(SignalRContext context) : base(context)
        {
        }

        public async Task ChangeStatusToFalse(int id)
        {
            var value = await _context.Discounts.FindAsync(id);
            value.Status = false;
            _context.SaveChanges();
        }


        public async Task ChangeStatusToTrue(int id)
        {
            var value = await _context.Discounts.FindAsync(id);
            value.Status = true;
            _context.SaveChanges();
        }

        public async Task<List<Discount>> GetAllActiveDiscounts()
        {
            var activeDiscountList = await _context.Discounts.Where(x => x.Status == true).ToListAsync();
            return activeDiscountList;

        }
    }
}
