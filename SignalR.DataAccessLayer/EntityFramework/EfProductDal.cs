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
    public class EfProductDal : GenericRepository<Product>, IProductDal
    {
        public EfProductDal(SignalRContext context) : base(context)
        {
        }

        public decimal AveragePriceOfProducts()
        {
            using var context = new SignalRContext();
            return context.Products.Average(x => x.Price);
        }

        public decimal AverageProductPriceOfHamburger()
        {
            var context = new SignalRContext();
            return context.Products.Where(x => x.CategoryID == (context.Categories.Where(y => y.Name == "Hamburger").Select(z => z.CategoryID).FirstOrDefault()))
                                   .Average(w => w.Price);
        }

        public List<Product> GetProductsWithCategories()
        {
            var context = new SignalRContext();
            var values = context.Products.Include(x => x.Category).ToList();
            return values;
        }

        public string MaxPriceProductName()
        {
            using var context = new SignalRContext();
            return context.Products.Where(x => x.Price == context.Products.Max(y => y.Price))
                                   .Select(z => z.ProductName)
                                   .FirstOrDefault();
        }

        public string MinPriceProductName()
        {
            using var context = new SignalRContext();
            return context.Products.Where(x => x.Price == context.Products.Min(y => y.Price))
                                   .Select(z => z.ProductName)
                                   .FirstOrDefault();
        }

        public int ProductCount()
        {
            using var context = new SignalRContext();
            return context.Products.Count();
        }

        public int ProductCountByCategoryNameDrink()
        {
            using var context = new SignalRContext();
            return context.Products.Where(x=>x.CategoryID == (context.Categories.Where(y=>y.Name == "İçecek").Select(z=>z.CategoryID).FirstOrDefault())).Count();
        }

        public int ProductCountByCategoryNameHamburger()
        {
            using var context = new SignalRContext();
            return context.Products.Where(x => x.CategoryID == (context.Categories.Where(y => y.Name == "Hamburger").Select(z => z.CategoryID).FirstOrDefault())).Count();
        }
    }
}
