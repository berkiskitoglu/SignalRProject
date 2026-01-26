using SignalRWebUI.Dtos.BasketDtos;
using SignalRWebUI.Services.Abstract;

namespace SignalRWebUI.Services.Concrete
{
    public class BasketApiService : IBasketApiService
    {
        private readonly HttpClient _client;

        public BasketApiService(HttpClient client)
        {
            _client = client;
        }

        public async Task<List<ResultBasketDto>> GetAllAsync()
        {
            return await _client.GetFromJsonAsync<List<ResultBasketDto>>("api/Baskets/GetAllBasketsWithProducts");
        }
    }
}
