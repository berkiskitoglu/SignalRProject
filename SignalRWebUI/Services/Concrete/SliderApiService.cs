using SignalRWebUI.Dtos.SliderDtos;
using SignalRWebUI.Services.Abstract;

namespace SignalRWebUI.Services.Concrete
{
    public class SliderApiService : ISliderApiService
    {
        private readonly HttpClient _client;

        public SliderApiService(HttpClient client)
        {
            _client = client;
        }

        public async Task CreateAsync(CreateSliderDto createSliderDto)
        {
            await _client.PostAsJsonAsync("api/Sliders", createSliderDto);
        }

        public async Task DeleteAsync(int id)
        {
            await _client.DeleteAsync($"api/Sliders/{id}");
        }


        public async Task<List<ResultSliderDto>> GetAllAsync()
        {
            var values = await _client.GetFromJsonAsync<List<ResultSliderDto>>("api/Sliders");
            return values ?? new List<ResultSliderDto>();
        }

        public async Task<GetSliderDto?> GetByIdAsync(int id)
        {
            return await _client.GetFromJsonAsync<GetSliderDto>($"api/Sliders/{id}");
        }
        public async Task UpdateAsync(int id, UpdateSliderDto updateSliderDto)
        {
            await _client.PutAsJsonAsync($"api/Sliders/{id}", updateSliderDto);
        }
    }
}
