namespace MyWebApi.DAL
{
    public class WeatherForecast
    {
        public int WeatherForecastId { get; set; }
        public DateTime Date { get; set; }
        public int TemperatureC { get; set; }
        public string? Summary { get; set; }
    }
}
