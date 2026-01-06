
using Spectre.Console;

namespace StockCli.src.Commands.GetStockMetric
{
    public class StockService : IStockService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IAnsiConsole _console;
        public StockService(IHttpClientFactory httpClientFactory, IAnsiConsole console)
        {
            _httpClientFactory = httpClientFactory;
            _console = console;
        }

        public string GetStockMetricData(string symbol, string apiKey)
        {
            var client = _httpClientFactory.CreateClient("StockApiClient");
            var response = client.GetAsync($"{client.BaseAddress}&symbol={symbol}&apikey={apiKey}").Result;

            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;
                _console.WriteLine(data);

                return data;
            }
            else
            {
                throw new Exception("Failed to retrieve stock metric data.");
            }
        }
    }
}