using MyWebApi.DAL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationContext>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("AppConnectionString")));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<ApplicationContext>();
    context.Database.EnsureCreated();
    // DbInitializer.Initialize(context);
}

app.UseSwagger();
app.UseSwaggerUI();


app.MapGet("/weatherforecasts", async(ApplicationContext context) => 
    await context.WeatherForecasts.ToListAsync());

app.Run();
