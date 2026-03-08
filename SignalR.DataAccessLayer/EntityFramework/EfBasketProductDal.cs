using Microsoft.EntityFrameworkCore;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EfBasketProductDal : GenericRepository<BasketProduct>, IBasketProductDal
    {
        public EfBasketProductDal(SignalRContext context) : base(context)
        {
        }

        public async Task<List<BasketProduct>> GetBasketProductsByBasketIdAsync(int basketId)
        {
            return await _context.BasketProducts.Include(x => x.Product).Where(x => x.BasketID == basketId).ToListAsync();
        }

        public async Task<BasketProduct> GetByBasketAndProductIdAsync(int basketId, int productId)
        {
            return await _context.BasketProducts.FirstOrDefaultAsync(x =>x.BasketID == basketId && x.ProductID == productId);

        }
    }
}
