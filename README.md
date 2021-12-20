# Demo af Docker og Docker Compose vha. Visual Studio 2022

Der benyttes f�lgende Visual Studio templates:

**MyWebApi:** Et standard WeatherForecast WebApi

**WebFrontEnd:** Et standard ASP.NET Razor WebApplication

> Branch: 1.WebApiDocker
> 
> Branch: 2.WebApiDockerCompose
> 
> Branch: 3.WebApiDatabaseDockerCompose

&nbsp;

## Test af WebFrontEnd og MyWebApi uden Docker support

Kontroll�r porten for *MyWebApi* (her http://localhost:27776) og tilret i *WebFrontEnd* `OnGet()`.

S�t *Multiple Startup Projects*, s� *MyWebApi* starter f�rst op, derefter *WebFrontEnd*.

K�r projekter i *IIS*.

&nbsp;

## To selvst�ndige Docker projekter

S�t *MyWebApi* til at v�re startup projekt og start det i *Docker* mode. Testes fra Swagger.

S�t *WebFrontEnd* til at v�re startup projekt.

I `OnGet()` skal *HttpClient BaseAddress* s�ttes til *maskinens IP-adresse*, samt den port som *MyWebApi* benytter. `Localhost` fungerer ikke!

Start projektet i *Docker* mode. 

