using Microsoft.EntityFrameworkCore;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EfBasketProductDal : GenericRepository<BasketProduct>, IBasketProductDal
    {
        public EfBasketProductDal(SignalRContext context) : base(context)
        {
        }

        public async Task<List<BasketProduct>> GetBasketProductsByBasketIdAsync(int basketId)
        {
           return await _context.BasketProducts.Include(x=>x.Product).Where(x=>x.BasketID == basketId).ToListAsync();
        }
    }
}
