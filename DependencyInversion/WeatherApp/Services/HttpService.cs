using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace WeatherApp.Services;

public class HttpService
{
    private readonly HttpClient _httpClient;

    public HttpService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<T?> GetFromJsonAsync<T>(string url)
    {
        return await _httpClient.GetFromJsonAsync<T>(url);
    }

}