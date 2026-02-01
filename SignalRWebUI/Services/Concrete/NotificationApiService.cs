using SignalRWebUI.Dtos.NotificationDtos;
using SignalRWebUI.Services.Abstract;

namespace SignalRWebUI.Services.Concrete
{
    public class NotificationApiService : INotificationApiService
    {
        private readonly HttpClient _client;

        public NotificationApiService(HttpClient client)
        {
            _client = client;
        }

        public async Task CreateAsync(CreateNotificationDto createNotificationDto)
        {
            await _client.PostAsJsonAsync("api/Notifications", createNotificationDto);
        }

        public async Task DeleteAsync(int id)
        {
            await _client.DeleteAsync($"api/Notifications/{id}");
        }


        public async Task<List<ResultNotificationDto>> GetAllAsync()
        {
            var values = await _client.GetFromJsonAsync<List<ResultNotificationDto>>("api/Notifications");
            return values ?? new List<ResultNotificationDto>();
        }

        public async Task<GetNotificationDto?> GetByIdAsync(int id)
        {
            return await _client.GetFromJsonAsync<GetNotificationDto>($"api/Notifications/{id}");
        }

        public async Task NotificationStatusChangeToFalse(int id)
        {
            await _client.GetAsync($"api/Notifications/NotificationChangeToFalse/{id}");
        }

        public async Task NotificationStatusChangeToTrue(int id)
        {
            await _client.GetAsync($"api/Notifications/NotificationChangeToTrue/{id}");
            
        }

        public async Task UpdateAsync(int id, UpdateNotificationDto updateNotificationDto)
        {
            await _client.PutAsJsonAsync($"api/Notifications/{id}", updateNotificationDto);
        }
    }
}
