using Microsoft.CodeAnalysis;
using SignalRWebUI.Dtos.BasketProductDtos;
using SignalRWebUI.Services.Abstract;

namespace SignalRWebUI.Services.Concrete
{
    public class BasketProductApiService : IBasketProductApiService
    {
        private readonly HttpClient _client;

        public BasketProductApiService(HttpClient client)
        {
            _client = client;
        }

        public async Task DeleteBasketProduct(int basketId, int productId)
        {
            await _client.DeleteAsync($"api/BasketProducts/{basketId}/{productId}");
        }
    }
}
