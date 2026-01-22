using Microsoft.EntityFrameworkCore;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EfProductDal : GenericRepository<Product>, IProductDal
    {
        public EfProductDal(SignalRContext context) : base(context)
        {
        }

        public async Task<List<Product>> GetProductsWithCategoriesAsync() => await _context.Products.Include(x => x.Category).ToListAsync();
        public async Task<int> ProductCount() =>  await _context.Products.CountAsync();
        public async Task<decimal> ProductPricaAverage() => await _context.Products.AverageAsync(x => x.Price);
        public async Task<string> ProductNameByMaxPrice() => await _context.Products.OrderByDescending(x => x.Price).Select(x => x.ProductName).FirstAsync(); 
        public async Task<string> ProductNameByMinPrice() => await _context.Products.OrderBy(x => x.Price).Select(x => x.ProductName).FirstAsync();
        private async Task<int> ProductCountByCategory(string categoryName) => await _context.Products.CountAsync(x => x.Category.CategoryName == categoryName);
        public async Task<int> ProductCountByCategoryNameDrink() => await ProductCountByCategory("İçecek");
        public async Task<int> ProductCountByCategoryNameHamburger() => await ProductCountByCategory("Hamburger");
        public async Task<decimal> AverageProductPriceHamburger()=> await _context.Products.Where(x => x.Category.CategoryName == "Hamburger").AverageAsync(x => x.Price);

    }
}
