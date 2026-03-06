using Newtonsoft.Json;
using SignalRWebUI.Dtos.RapidApiDtos;
using SignalRWebUI.Services.Abstract;
using SignalRWebUI.ViewModels;

public class TastyApiService : ITastyApiService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;

    public TastyApiService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
    }

    public async Task<List<TastyApiViewModel>> GetRecipesAsync()
    {
        var apiKey = _configuration["RapidApi:Key"];
        var apiHost = _configuration["RapidApi:Host"];

        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri("https://tasty.p.rapidapi.com/recipes/list?from=0&size=20"),
            Headers =
            {
                { "x-rapidapi-key", apiKey },
                { "x-rapidapi-host", apiHost },
            },
        };

        using var response = await _httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();

        var body = await response.Content.ReadAsStringAsync();
        var wrapper = JsonConvert.DeserializeObject<ResultTastyApiWrapper>(body);
        var values = wrapper?.Results ?? new List<ResultTastyApi>();

        return values.Select(x => new TastyApiViewModel
        {
            Name = x.Name ?? "İsimsiz Tarif",
            ThumbnailUrl = x.thumbnail_url ?? "/images/default.jpg",
            VideoUrl = x.original_video_url ?? "#",
            TotalTime = x.total_time_minutes > 0
                ? $"{x.total_time_minutes} dakika"
                : "Belirtilmemiş"
        }).ToList();
    }
}