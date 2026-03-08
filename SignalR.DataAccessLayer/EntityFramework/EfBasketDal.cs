using Microsoft.EntityFrameworkCore;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EfBasketDal : GenericRepository<Basket>, IBasketDal
    {
        public EfBasketDal(SignalRContext context) : base(context)
        {
        }

        public async Task<List<Basket>> GetBasketByMenuTableNumber(int id) => await _context.Baskets.Include(b => b.BasketProducts)
                                                                            .ThenInclude(bp => bp.Product)
                                                                            .Where(b => b.MenuTableID == id)
                                                                            .ToListAsync();
        public async Task<List<Basket>> GetAllBasketsWithProductsAsync()
        {
            return await _context.Baskets
                .Include(b => b.BasketProducts)
                    .ThenInclude(bp => bp.Product)
                .ToListAsync();
        }


    }
}
