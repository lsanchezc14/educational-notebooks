using System.ComponentModel;
using Spectre.Console.Cli;

namespace StockCli.src.Commands.GetStockMetric
{
    public class GetStockMetricSettings : CommandSettings
    {
        [CommandArgument(0, "<symbol>")]
        [Description("The stock symbol to retrieve metrics for")]
        public string Symbol { get; init; } = string.Empty;

        [CommandOption("-k|--key")]
        [Description("API key for the stock service")]
        public string ApiKey { get; init; } = string.Empty;
    }
}