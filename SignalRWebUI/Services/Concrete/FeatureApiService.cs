using SignalRWebUI.Dtos.FeatureDtos;
using SignalRWebUI.Services.Abstract;

namespace SignalRWebUI.Services.Concrete
{
    public class FeatureApiService : IFeatureApiService
    {
        private readonly HttpClient _client;

        public FeatureApiService(HttpClient client)
        {
            _client = client;
        }

        public async Task CreateAsync(CreateFeatureDto createFeatureDto)
        {
            await _client.PostAsJsonAsync("api/Features", createFeatureDto);
        }

        public async Task DeleteAsync(int id)
        {
            await _client.DeleteAsync($"api/Features/{id}");
        }


        public async Task<List<ResultFeatureDto>> GetAllAsync()
        {
            var values = await _client.GetFromJsonAsync<List<ResultFeatureDto>>("api/Features");
            return values ?? new List<ResultFeatureDto>();
        }

        public async Task<GetFeatureDto?> GetByIdAsync(int id)
        {
            return await _client.GetFromJsonAsync<GetFeatureDto>($"api/Features/{id}");
        }
        public async Task UpdateAsync(int id, UpdateFeatureDto updateFeatureDto)
        {
            await _client.PutAsJsonAsync($"api/Features/{id}", updateFeatureDto);
        }
    }
}
