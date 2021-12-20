using Microsoft.EntityFrameworkCore;

namespace MyWebApi.DAL
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public DbSet<WeatherForecast> WeatherForecasts => Set<WeatherForecast>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WeatherForecast>().HasData(
                new WeatherForecast
                {
                    WeatherForecastId = 1,
                    Date = DateTime.Now, TemperatureC = 24, Summary = "Solskind"
                },
                new WeatherForecast
                {
                    WeatherForecastId = 2,
                    Date = DateTime.Now,
                    TemperatureC = 18,
                    Summary = "Blæsende"
                },
                new WeatherForecast
                {
                    WeatherForecastId = 3,
                    Date = DateTime.Now,
                    TemperatureC = 20,
                    Summary = "Overskyet"
                },
                new WeatherForecast
                {
                    WeatherForecastId = 4,
                    Date = DateTime.Now,
                    TemperatureC = 15,
                    Summary = "Regnvejr"
                },
                new WeatherForecast
                {
                    WeatherForecastId = 5,
                    Date = DateTime.Now,
                    TemperatureC = 19,
                    Summary = "Gråvejr"
                }
            );
        }
    }
}
