using SignalRWebUI.Dtos.TestimonialDtos;
using SignalRWebUI.Services.Abstract;

namespace SignalRWebUI.Services.Concrete
{
    public class TestimonialApiService : ITestimonialApiService
    {
        private readonly HttpClient _client;

        public TestimonialApiService(HttpClient client)
        {
            _client = client;
        }

        public async Task CreateAsync(CreateTestimonialDto createTestimonialDto)
        {
            await _client.PostAsJsonAsync("api/Testimonials", createTestimonialDto);
        }

        public async Task DeleteAsync(int id)
        {
            await _client.DeleteAsync($"api/Testimonials/{id}");
        }


        public async Task<List<ResultTestimonialDto>> GetAllAsync()
        {
            var values = await _client.GetFromJsonAsync<List<ResultTestimonialDto>>("api/Testimonials");
            return values ?? new List<ResultTestimonialDto>();
        }

        public async Task<GetTestimonialDto?> GetByIdAsync(int id)
        {
            return await _client.GetFromJsonAsync<GetTestimonialDto>($"api/Testimonials/{id}");
        }
        public async Task UpdateAsync(int id, UpdateTestimonialDto updateTestimonialDto)
        {
            await _client.PutAsJsonAsync($"api/Testimonials/{id}", updateTestimonialDto);
        }
    }
}
