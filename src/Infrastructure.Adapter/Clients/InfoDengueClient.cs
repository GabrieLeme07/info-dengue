using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace Infrastructure.Adapter.Clients;

public class InfoDengueClient<T>
{
    private readonly HttpClient _httpClient;

    public InfoDengueClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }

    public async Task<(bool IsSuccessResponse, HttpResponseMessage ResponseMessage, string ErrorCode)> PostJson<W>(Guid idempotencykey, string url, W requestBody)
    {
        var requestMessage = new HttpRequestMessage(HttpMethod.Post, url)
        {
            Content = CreatedStringContent(requestBody)
        };

        return await RequestAsync(requestMessage, idempotencykey);
    }

    public async Task<(bool IsSuccessResponse, HttpResponseMessage Response, string ErrorCode)> Get(string url)
    {
        var requestMessage = new HttpRequestMessage(HttpMethod.Get, url);

        return await RequestAsync(requestMessage, null);
    }

    private async Task<(bool isSuccessStatusCode, HttpResponseMessage ResponseMessage, string ErrorCode)> RequestAsync(HttpRequestMessage requestMessage, Guid? idempotencykey)
    {

        var response = await _httpClient.SendAsync(requestMessage);
        return (response.IsSuccessStatusCode, response, response.StatusCode.ToString());
    }

    private static StringContent CreatedStringContent<T>(T requestBody)
        => new(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");

}
