using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public async Task TAddAsync(Product entity) => await _productDal.AddAsync(entity);

        public async Task TDeleteAsync(Product entity) => await _productDal.DeleteAsync(entity);

        public async Task TUpdateAsync(Product entity) => await _productDal.UpdateAsync(entity);

        public async Task<Product?> TGetByIDAsync(int id) => await _productDal.GetByIDAsync(id);

        public async Task<List<Product>> TGetListAllAsync() => await _productDal.GetListAllAsync();

        public async Task<List<Product>> TGetProductsWithCategoriesAsync() => await _productDal.GetProductsWithCategoriesAsync();

        public async Task<int> TProductCount() => await _productDal.ProductCount();

        public async Task<int> TProductCountByCategoryNameHamburger() => await _productDal.ProductCountByCategoryNameHamburger();

        public async Task<int> TProductCountByCategoryNameDrink() => await _productDal.ProductCountByCategoryNameDrink();

        public async Task<decimal> TProductPriceAverage() => await _productDal.ProductPricaAverage();

        public async Task<string> TProductNameByMaxPrice() => await _productDal.ProductNameByMaxPrice();

        public async Task<string> TProductNameByMinPrice() => await _productDal.ProductNameByMinPrice();

        public async Task<decimal> TAverageProductPriceHamburger() => await _productDal.AverageProductPriceHamburger();

    }
}