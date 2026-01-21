using SignalRWebUI.Dtos.DiscountDtos;
using SignalRWebUI.Services.Abstract;

namespace SignalRWebUI.Services.Concrete
{
    public class DiscountApiService : IDiscountApiService
    {
        private readonly HttpClient _client;

        public DiscountApiService(HttpClient client)
        {
            _client = client;
        }

        public async Task CreateAsync(CreateDiscountDto createDiscountDto)
        {
            await _client.PostAsJsonAsync("api/Discounts", createDiscountDto);
        }

        public async Task DeleteAsync(int id)
        {
            await _client.DeleteAsync($"api/Discounts/{id}");
        }


        public async Task<List<ResultDiscountDto>> GetAllAsync()
        {
            var values = await _client.GetFromJsonAsync<List<ResultDiscountDto>>("api/Discounts");
            return values ?? new List<ResultDiscountDto>();
        }

        public async Task<GetDiscountDto?> GetByIdAsync(int id)
        {
            return await _client.GetFromJsonAsync<GetDiscountDto>($"api/Discounts/{id}");
        }
        public async Task UpdateAsync(int id, UpdateDiscountDto updateDiscountDto)
        {
            await _client.PutAsJsonAsync($"api/Discounts/{id}", updateDiscountDto);
        }
    }
}
