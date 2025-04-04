using Infrastructure.Adapter.Clients;
using Infrastructure.Adapter.InfoDengue.DTOs;
using Infrastructure.Adapter.InfoDengue.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Text.Json;

namespace Infrastructure.Adapter.InfoDengue.Adapters;

public class InfodengueAdapter(IConfiguration configuration, HttpClient httpClient) : InfoDengueClient<InfodengueAdapter>(httpClient), IInfodengueAdapter
{
    private readonly string _baseURL = configuration["Infodengue-BaseURL"];

    public async Task<List<InfodengueResponseItemDto>> GetReportAsync(InfodengueRequestDto parameters)
    {
        var url = $"{_baseURL}/alertcity";

        var queryParams = new Dictionary<string, string>
            {
                { "city", parameters.City },
                { "disease", parameters.Disease },
                { "arbovirus", parameters.Arbovirus },
                { "startWeek", parameters.StartWeek.ToString() },
                { "endWeek", parameters.EndWeek.ToString() },
                { "geocode", parameters.IBGECode },
                { "format", "json" }
            };

        var queryString = await new FormUrlEncodedContent(queryParams).ReadAsStringAsync();
        var requestUrl = $"{url}?{queryString}";

        var response = await Get(requestUrl);

        if (response.IsSuccessResponse)
        {
            var json = await response.Response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var result = JsonSerializer.Deserialize<List<InfodengueResponseItemDto>>(json, options);
            return result;
        }
        else
        {
            throw new Exception($"Infodengue API request failed with status code {response.ErrorCode}");
        }
    }
}
