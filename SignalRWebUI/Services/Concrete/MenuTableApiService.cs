using SignalRWebUI.Dtos.MenuTableDtos;
using SignalRWebUI.Services.Abstract;

namespace SignalRWebUI.Services.Concrete
{
    public class MenuTableApiService : IMenuTableApiService
    {
        private readonly HttpClient _client;

        public MenuTableApiService(HttpClient client)
        {
            _client = client;
        }

        public async Task CreateAsync(CreateMenuTableDto createMenuTableDto)
        {
            await _client.PostAsJsonAsync("api/MenuTables", createMenuTableDto);
        }

        public async Task DeleteAsync(int id)
        {
            await _client.DeleteAsync($"api/MenuTables/{id}");
        }


        public async Task<List<ResultMenuTableDto>> GetAllAsync()
        {
            var values = await _client.GetFromJsonAsync<List<ResultMenuTableDto>>("api/MenuTables");
            return values ?? new List<ResultMenuTableDto>();
        }

        public async Task<GetMenuTableDto?> GetByIdAsync(int id)
        {
            return await _client.GetFromJsonAsync<GetMenuTableDto>($"api/MenuTables/{id}");
        }
        public async Task UpdateAsync(int id, UpdateMenuTableDto updateMenuTableDto)
        {
            await _client.PutAsJsonAsync($"api/MenuTables/{id}", updateMenuTableDto);
        }
    }
}
