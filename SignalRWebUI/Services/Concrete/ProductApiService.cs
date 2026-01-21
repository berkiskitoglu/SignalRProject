using SignalRWebUI.Dtos.ProductDtos;
using SignalRWebUI.Services.Abstract;

namespace SignalRWebUI.Services.Concrete
{
    public class ProductApiService : IProductApiService
    {
        private readonly HttpClient _client;

        public ProductApiService(HttpClient client)
        {
            _client = client;
        }

        public async Task CreateAsync(CreateProductDto createProductDto)
        {
            await _client.PostAsJsonAsync("api/Products", createProductDto);
        }

        public async Task DeleteAsync(int id)
        {
            await _client.DeleteAsync($"api/Products/{id}");
        }

        public async Task<List<ResultProductDto>> GetAllAsync()
        {
            var values = await _client.GetFromJsonAsync<List<ResultProductDto>>("api/Products");
            return values ?? new List<ResultProductDto>();      
        }

        public async Task<GetProductDto?> GetByIdAsync(int id)
        {
            return await _client.GetFromJsonAsync<GetProductDto>($"api/Products/{id}");
        }

        public async Task<List<ResultProductWithCategoryDto>> GetProductsWithCategoryAsync()
        {
            var values = await _client.GetFromJsonAsync<List<ResultProductWithCategoryDto>>("api/Products/ProductListWithCategory");
            return values ?? new List<ResultProductWithCategoryDto>();
        }

        public async Task UpdateAsync(int id, UpdateProductDto updateProductDto)
        {
            await _client.PutAsJsonAsync($"api/Products/{id}", updateProductDto);
        }

    }
}
