using Microsoft.AspNetCore.Mvc.RazorPages;
using WebFrontEnd.Models;

namespace WebFrontEnd.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public List<WeatherForecast> WeatherForecasts { get; set; }
        public string ErrorMessage { get; set; }

        public async Task OnGet()
        {
            using HttpClient client = new() { BaseAddress = new Uri("http://mywebapi") };   // Docker
            //using HttpClient client = new() { BaseAddress = new Uri("http://localhost:27776") };            // Non-Docker

            try
            {
                WeatherForecasts = await client.GetFromJsonAsync<List<WeatherForecast>>("WeatherForecasts");
            }
            catch (Exception ex)
            {
                ErrorMessage = $"En fejl opstod: {ex.Message}";
            }
        }
    }
}