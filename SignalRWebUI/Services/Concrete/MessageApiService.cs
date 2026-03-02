using SignalRWebUI.Dtos.MessageDtos;
using SignalRWebUI.Dtos.MessageDtos;
using SignalRWebUI.Services.Abstract;

namespace SignalRWebUI.Services.Concrete
{
    public class MessageApiService : IMessageApiService
    {
        private readonly HttpClient _client;

        public MessageApiService(HttpClient client)
        {
            _client = client;
        }

        public async Task CreateAsync(CreateMessageDto createMessageDto)
        {
            await _client.PostAsJsonAsync("api/Messages", createMessageDto);
        }

        public async Task DeleteAsync(int id)
        {
            await _client.DeleteAsync($"api/Messages/{id}");
        }


        public async Task<List<ResultMessageDto>> GetAllAsync()
        {
            var values = await _client.GetFromJsonAsync<List<ResultMessageDto>>("api/Messages");
            return values ?? new List<ResultMessageDto>();
        }

        public async Task<GetMessageDto?> GetByIdAsync(int id)
        {
            return await _client.GetFromJsonAsync<GetMessageDto>($"api/Messages/{id}");
        }
        public async Task UpdateAsync(int id, UpdateMessageDto updateMessageDto)
        {
            await _client.PutAsJsonAsync($"api/Messages/{id}", updateMessageDto);
        }
    }
}
