using Microsoft.Extensions.DependencyInjection;
using Spectre.Console.Cli;
using StockCli.src.Commands.GetStockMetric;
using StockCli.src.Service;


namespace StockCli;
class Program
{
    static async Task<int> Main(string[] args)
    {
        var services = new ServiceCollection();
        services.AddHttpClient("StockApiClient", client =>
        {
            client.BaseAddress = new Uri("https://www.alphavantage.co/query?function=OVERVIEW");
            client.DefaultRequestHeaders.Add("Accept", "application/json");
        });
        services.AddSingleton<IStockService, StockService>();

        var registrarSpectreConsole = new TypeRegistrar(services);

        var app = new CommandApp(registrarSpectreConsole);
        app.Configure(config =>
        {
            config.AddCommand<GetStockMetricCommand>("get-stock-metric")
                .WithDescription("Retrieve stock metric data for a given symbol");
        });

        return await app.RunAsync(args);
    }
}
