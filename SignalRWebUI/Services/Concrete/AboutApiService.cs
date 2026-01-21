using SignalRWebUI.Dtos.AboutDtos;
using SignalRWebUI.Services.Abstract;

namespace SignalRWebUI.Services.Concrete
{
    public class AboutApiService : IAboutApiService
    {
        private readonly HttpClient _client;

        public AboutApiService(HttpClient client)
        {
            _client = client;
        }

        public async Task CreateAsync(CreateAboutDto createAboutDto)
        {
            await _client.PostAsJsonAsync("api/Abouts", createAboutDto);
        }

        public async Task DeleteAsync(int id)
        {
            await _client.DeleteAsync($"api/Abouts/{id}");
        }


        public async Task<List<ResultAboutDto>> GetAllAsync()
        {
            var values = await _client.GetFromJsonAsync<List<ResultAboutDto>>("api/Abouts");
            return values ?? new List<ResultAboutDto>();
        }

        public async Task<GetAboutDto?> GetByIdAsync(int id)
        {
            return await _client.GetFromJsonAsync<GetAboutDto>($"api/Abouts/{id}");
        }
        public async Task UpdateAsync(int id, UpdateAboutDto updateAboutDto)
        {
            await _client.PutAsJsonAsync($"api/Abouts/{id}", updateAboutDto);
        }
    }
}
