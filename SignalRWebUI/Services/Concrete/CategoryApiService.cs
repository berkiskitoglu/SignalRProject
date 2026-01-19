using Microsoft.AspNetCore.Mvc;
using SignalRWebUI.Dtos.CategoryDtos;
using SignalRWebUI.Services.Abstract;

namespace SignalRWebUI.Services.Concrete
{
    public class CategoryApiService : ICategoryApiService
    {
        private readonly HttpClient _client;

        public CategoryApiService(HttpClient client)
        {
            _client = client;
        }

        public async Task CreateAsync(CreateCategoryDto createCategoryDto)
        {
            await _client.PostAsJsonAsync("api/Categories",createCategoryDto);
        }

        public async Task DeleteAsync(int id)
        {
            await _client.DeleteAsync($"api/Categories/{id}");
        }


        public async Task<List<ResultCategoryDto>> GetAllAsync()
        {
            var values = await _client.GetFromJsonAsync<List<ResultCategoryDto>>("api/Categories");
            return values ?? new List<ResultCategoryDto>();
        }

        [HttpGet]
        public async Task<GetCategoryDto?> GetByIdAsync(int id)
        {
            return await _client.GetFromJsonAsync<GetCategoryDto>($"api/Categories/{id}");
        }
        [HttpPost]
        public async Task UpdateAsync(int id , UpdateCategoryDto updateCategoryDto)
        {
            await _client.PutAsJsonAsync($"api/Categories/{id}", updateCategoryDto);
        }
    }
}
