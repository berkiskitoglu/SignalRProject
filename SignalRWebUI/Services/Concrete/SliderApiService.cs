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

        public async Task<List<ResultSliderDto>> GetAllAsync()  => await _client.GetFromJsonAsync<List<ResultSliderDto>>("api/Sliders") ?? new List<ResultSliderDto>();
        

     
    }
}
