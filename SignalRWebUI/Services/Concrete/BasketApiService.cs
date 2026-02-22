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

        public async Task CreateAsync(CreateBasketDto createBasketDto)
        {
             await _client.PostAsJsonAsync("api/Baskets", createBasketDto);
        }

        public async Task<List<ResultBasketDto>> GetByIdAsync(int id)
        {
            return await _client.GetFromJsonAsync<List<ResultBasketDto>>($"api/Baskets/{id}");

        }

  
    }
}
