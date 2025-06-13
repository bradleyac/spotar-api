using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc;
using SpotAR.API.Models;

namespace SpotAR.API.Services;

public class PlanesService(IHttpClientFactory httpClientFactory)
{
    private IHttpClientFactory _httpClientFactory = httpClientFactory;

    public async Task<List<Aircraft>> GetPlanesNearMe(double latitude, double longitude)
    {
        var client = _httpClientFactory.CreateClient("ADSB-API");

        var result = await client.GetFromJsonAsync<AdsbResult>($"v2/lat/{latitude}/lon/{longitude}/dist/25");

        return result.Planes;
    }
}