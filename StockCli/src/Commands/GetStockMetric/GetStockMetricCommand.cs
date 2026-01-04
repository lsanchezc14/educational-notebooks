
using Spectre.Console;
using Spectre.Console.Cli;

namespace StockCli.src.Commands.GetStockMetric
{
    public class GetStockMetricCommand : Command<GetStockMetricSettings>
    {
        private readonly IStockService _stockService;
        private readonly IAnsiConsole _console;

        public GetStockMetricCommand(IStockService stockService, IAnsiConsole console)
        {
            _stockService = stockService;
            _console = console;
        }

        public override int Execute(CommandContext context, GetStockMetricSettings settings, CancellationToken cancellationToken)
        {
            var metricName = _stockService.GetStockMetricData(settings.Symbol, settings.ApiKey);
            _console.WriteLine($"Metric Name: {metricName}");
            return 0;
        }
    }
}