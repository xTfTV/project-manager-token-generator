using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ProjectManager.TokenGenerator.Services;

public class TokenApiService
{
    private readonly HttpClient _httpClient;
    private readonly CookieContainer _cookieContainer;

    public TokenApiService(string BaseUrl)
    {
        _cookieContainer = new CookieContainer();

        var handler = new HttpClientHandler
        {
            CookieContainer = _cookieContainer,
            UseCookies = true
        };

        _httpClient = new HttpClient(handler)
        {
            BaseAddress = new System.Uri(BaseUrl)
        };
    }

    public async Task<string?> GenerateTokenAsync(string emailAddress, string password)
    {
        var request = new
        {
            emailAddress,
            password
        };

        var response = await _httpClient.PostAsJsonAsync("v1/api/Auth/login", request);

        if (!response.IsSuccessStatusCode)
        {
            return null;
        }

        var cookies = _cookieContainer.GetCookies(_httpClient.BaseAddress!);

        return cookies["access_token"]?.Value;
    }
}
