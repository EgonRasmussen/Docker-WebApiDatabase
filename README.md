Ref: [Tutorial: Create a multi-container app with Docker Compose](https://docs.microsoft.com/en-us/visualstudio/containers/tutorial-multicontainer?view=vs-2022)

Ref: [CRUD Operations in ASP.NET Core and SQL Server with Docker](https://www.yogihosting.com/docker-aspnet-core-sql-server-crud/)

### MS SQL Server 2019 Express og test med SSMS

Hent følgende image: 

    docker pull mcr.microsoft.com/mssql/server:2019-latest

Kør denne container:

    docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=P@ssw0rd" -e "MSSQL_PID=Express" -p 1433:1433 --name mssqlserver -d mcr.microsoft.com/mssql/server:2019-latest

Test med SSMS og log på med: `Server name: localhost, 1433` og SQL Server Authentication


### WebApi benytter databasen

SQL Serveren kører i sin container, mens WebApi kører normalt i IIS. Husk at rette Connectionstring: `Server=localhost,1433`

Test at WebApi kan tilgå database serveren og opretter og seeder databasen.


### Opret Docker Compose

Slet MSSQL containeren. Opret en Docker Compose for både WebFrontEnd og MyWebApi. Tilføj MSSQLServeren. Rækkefølgen i docker-compose filen er vigtig:

```
version: '3.4'

services:
  mssqlserver:
    image: mcr.microsoft.com/mssql/server:2019-latest
    container_name: mssqlserver
    environment:
      - SA_PASSWORD=P@ssw0rd
      - ACCEPT_EULA=Y
      - MSSQL_PID=Express
    ports:
      - "1433:1433"

  mywebapi:
    image: ${DOCKER_REGISTRY-}mywebapi
    build:
      context: .
      dockerfile: MyWebApi/Dockerfile

  webfrontend:
    image: ${DOCKER_REGISTRY-}webfrontend
    build:
      context: .
      dockerfile: WebFrontEnd/Dockerfile
```

Husk at ændre connectionstring i WebApi til: `Server=mssqlserver,1433`

Test ved at starte Docker-Compose projektet op.

Når browseren viser fejl ved opstart, skal den blot refreshes!