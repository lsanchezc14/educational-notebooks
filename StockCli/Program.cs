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
        services.AddSingleton<IStockService, StockService>();

        var registrar = new TypeRegistrar(services);

        var app = new CommandApp(registrar);
        app.Configure(config =>
        {
            config.AddCommand<GetStockMetricCommand>("--get-stock-metric")
                .WithDescription("Retrieve stock metric data for a given symbol");
        });

        return await app.RunAsync(args);
    }
}
