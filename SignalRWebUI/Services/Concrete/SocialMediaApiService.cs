using SignalRWebUI.Dtos.SocialMediaDtos;
using SignalRWebUI.Services.Abstract;

namespace SignalRWebUI.Services.Concrete
{
    public class SocialMediaApiService : ISocialMediaApiService
    {
        private readonly HttpClient _client;

        public SocialMediaApiService(HttpClient client)
        {
            _client = client;
        }

        public async Task CreateAsync(CreateSocialMediaDto createSocialMediaDto)
        {
            await _client.PostAsJsonAsync("api/SocialMedias", createSocialMediaDto);
        }

        public async Task DeleteAsync(int id)
        {
            await _client.DeleteAsync($"api/SocialMedias/{id}");
        }


        public async Task<List<ResultSocialMediaDto>> GetAllAsync()
        {
            var values = await _client.GetFromJsonAsync<List<ResultSocialMediaDto>>("api/SocialMedias");
            return values ?? new List<ResultSocialMediaDto>();
        }

        public async Task<GetSocialMediaDto?> GetByIdAsync(int id)
        {
            return await _client.GetFromJsonAsync<GetSocialMediaDto>($"api/SocialMedias/{id}");
        }
        public async Task UpdateAsync(int id, UpdateSocialMediaDto updateSocialMediaDto)
        {
            await _client.PutAsJsonAsync($"api/SocialMedias/{id}", updateSocialMediaDto);
        }
    }
}
