using SignalRWebUI.Dtos.BookingDtos;
using SignalRWebUI.Services.Abstract;

namespace SignalRWebUI.Services.Concrete
{
    public class BookingApiService : IBookingApiService
    {
        private readonly HttpClient _client;

        public BookingApiService(HttpClient client)
        {
            _client = client;
        }

        public async Task CreateAsync(CreateBookingDto createBookingDto)
        {
            await _client.PostAsJsonAsync("api/Bookings", createBookingDto);
        }

        public async Task DeleteAsync(int id)
        {
            await _client.DeleteAsync($"api/Bookings/{id}");
        }


        public async Task<List<ResultBookingDto>> GetAllAsync()
        {
            var values = await _client.GetFromJsonAsync<List<ResultBookingDto>>("api/Bookings");
            return values ?? new List<ResultBookingDto>();
        }

        public async Task<GetBookingDto?> GetByIdAsync(int id)
        {
            return await _client.GetFromJsonAsync<GetBookingDto>($"api/Bookings/{id}");
        }
        public async Task UpdateAsync(int id, UpdateBookingDto updateBookingDto)
        {
            await _client.PutAsJsonAsync($"api/Bookings/{id}", updateBookingDto);
        }
    }
}
