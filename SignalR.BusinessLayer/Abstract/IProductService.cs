using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Abstract
{
    public interface IProductService : IGenericService<Product>
    {
       Task<List<Product>> TGetProductsWithCategoriesAsync();
        Task<int> TProductCount();
        Task<int> TProductCountByCategoryNameHamburger();
        Task<int> TProductCountByCategoryNameDrink();
        Task<decimal> TProductPriceAverage();
        Task<string> TProductNameByMaxPrice();
        Task<string> TProductNameByMinPrice();
        Task<decimal> TAverageProductPriceHamburger();


    }
}
