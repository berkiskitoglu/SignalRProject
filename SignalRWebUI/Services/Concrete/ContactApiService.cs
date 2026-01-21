using SignalRWebUI.Dtos.ContactDtos;
using SignalRWebUI.Services.Abstract;

namespace SignalRWebUI.Services.Concrete
{
    public class ContactApiService : IContactApiService
    {
        private readonly HttpClient _client;

        public ContactApiService(HttpClient client)
        {
            _client = client;
        }

        public async Task CreateAsync(CreateContactDto createContactDto)
        {
            await _client.PostAsJsonAsync("api/Contacts", createContactDto);
        }

        public async Task DeleteAsync(int id)
        {
            await _client.DeleteAsync($"api/Contacts/{id}");
        }


        public async Task<List<ResultContactDto>> GetAllAsync()
        {
            var values = await _client.GetFromJsonAsync<List<ResultContactDto>>("api/Contacts");
            return values ?? new List<ResultContactDto>();
        }

        public async Task<GetContactDto?> GetByIdAsync(int id)
        {
            return await _client.GetFromJsonAsync<GetContactDto>($"api/Contacts/{id}");
        }
        public async Task UpdateAsync(int id, UpdateContactDto updateContactDto)
        {
            await _client.PutAsJsonAsync($"api/Contacts/{id}", updateContactDto);
        }
    }
}
