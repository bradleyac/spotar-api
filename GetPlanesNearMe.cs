using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using SpotAR.API.Services;

namespace SpotAR.API;

public class GetPlanesNearMe
{
    private readonly ILogger<GetPlanesNearMe> _logger;
    private readonly PlanesService _planesService;

    public GetPlanesNearMe(ILogger<GetPlanesNearMe> logger, PlanesService planesService)
    {
        _logger = logger;
        _planesService = planesService;
    }

    [Function("GetPlanesNearMe")]
    public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "planes/nearby/{latitude:double}/{longitude:double}")] HttpRequest req, string latitude, string longitude)
    {
        var result = await _planesService.GetPlanesNearMe(double.Parse(latitude), double.Parse(longitude));
        _logger.LogInformation("C# HTTP trigger function processed a request.");

        return new JsonResult(result);
    }
}