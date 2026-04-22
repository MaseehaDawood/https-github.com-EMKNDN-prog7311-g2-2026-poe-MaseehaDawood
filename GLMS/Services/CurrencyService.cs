namespace GLMS.Services
{
    using System.Text.Json;

    public class CurrencyService
    {
        private readonly HttpClient _http;

        public CurrencyService(HttpClient http)
        {
            _http = http;
        }

        public async Task<double> GetUsdToZar()
        {
            var response = await _http.GetStringAsync("https://open.er-api.com/v6/latest/USD");
            var data = JsonDocument.Parse(response);

            return data.RootElement.GetProperty("rates").GetProperty("ZAR").GetDouble();
        }
    }
}
