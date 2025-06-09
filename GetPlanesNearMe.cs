using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace SpotAR.API;

public class GetPlanesNearMe
{
    private readonly ILogger<GetPlanesNearMe> _logger;

    public GetPlanesNearMe(ILogger<GetPlanesNearMe> logger)
    {
        _logger = logger;
    }

    [Function("GetPlanesNearMe")]
    public IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequest req)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request.");
        return new OkObjectResult("Welcome to Azure Functions!");
    }
}