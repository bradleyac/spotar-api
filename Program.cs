using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SpotAR.API.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;

var builder = new HostBuilder();

builder.ConfigureFunctionsWebApplication()
    .ConfigureServices(configureServices)
    .Build()
    .Run();

void configureServices(HostBuilderContext context, IServiceCollection services)
{
    var config = context.Configuration;
    var rapidApiUrl = config.GetValue<Uri>("RapidApiUrl");
    var rapidApiHost = config.GetValue<string>("RapidApiHost");
    var rapidApiKey = config.GetValue<string>("RapidApiKey");

    services.AddSingleton<PlanesService>();
    services.AddHttpClient("ADSB-API", conf =>
    {
        conf.BaseAddress = rapidApiUrl;
        conf.DefaultRequestHeaders.Add("x-rapidapi-host", rapidApiHost);
        conf.DefaultRequestHeaders.Add("x-rapidapi-key", rapidApiKey);
    });
    services.AddApplicationInsightsTelemetryWorkerService();
    services.ConfigureFunctionsApplicationInsights();
}