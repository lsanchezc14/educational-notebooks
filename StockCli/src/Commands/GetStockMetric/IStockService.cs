namespace StockCli.src.Commands.GetStockMetric
{
    public interface IStockService
    {
        string GetStockMetricData(string symbol, string apiKey);
    }
}