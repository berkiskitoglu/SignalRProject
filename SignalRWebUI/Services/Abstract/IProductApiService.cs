using SignalRWebUI.Dtos.ProductDtos;

namespace SignalRWebUI.Services.Abstract
{
    public interface IProductApiService : IGenericApiService<ResultProductDto,CreateProductDto,UpdateProductDto,GetProductDto>
    {
        Task<List<ResultProductWithCategoryDto>> GetProductsWithCategoryAsync();

    }
}
