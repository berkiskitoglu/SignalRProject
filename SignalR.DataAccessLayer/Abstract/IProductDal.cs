using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.Abstract
{
    public interface IProductDal : IGenericDal<Product>
    {
        Task<List<Product>> GetProductsWithCategoriesAsync();
        Task<int> ProductCount();
        Task<int> ProductCountByCategoryNameHamburger();
        Task<int> ProductCountByCategoryNameDrink();
        Task<decimal> ProductPricaAverage();
        Task<string> ProductNameByMaxPrice();
        Task<string> ProductNameByMinPrice();
        Task<decimal> AverageProductPriceHamburger();

    }
}
