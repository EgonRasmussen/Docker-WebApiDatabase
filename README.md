# Demo af Docker og Docker Compose vha. Visual Studio 2022

Der benyttes følgende Visual Studio templates:

**MyWebApi:** Et standard WeatherForecast WebApi

**WebFrontEnd:** Et standard ASP.NET Razor WebApplication

> Branch: 1.WebApiDocker
> 
> Branch: 2.WebApiDockerCompose
> 
> Branch: 3.WebApiDatabaseDockerCompose

&nbsp;

## Test af WebFrontEnd og MyWebApi uden Docker support

Kontrollér porten for *MyWebApi* (her http://localhost:27776) og tilret i *WebFrontEnd* `OnGet()`.

Sæt *Multiple Startup Projects*, så *MyWebApi* starter først op, derefter *WebFrontEnd*.

Kør projekter i *IIS*.

&nbsp;

## To selvstændige Docker projekter

Sæt *MyWebApi* til at være startup projekt og start det i *Docker* mode. Testes fra Swagger.

Sæt *WebFrontEnd* til at være startup projekt.

I `OnGet()` skal *HttpClient BaseAddress* sættes til *maskinens IP-adresse*, samt den port som *MyWebApi* benytter. `Localhost` fungerer ikke!

Start projektet i *Docker* mode. 

