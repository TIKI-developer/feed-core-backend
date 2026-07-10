Feed is a backend content aggregation platform built with .NET 10, ASP.NET Core, and PostgreSQL.
It periodically collects publications from multiple external sources, normalizes and aggregates the data into a centralized database, exposing it through a unified API.
# Development

## Deployment instructions
You have two ways to deploy the application:
 - Run the application on host machine
 - Using Docker Compose (recommended)

### Running on host machine
Run dependencies services on your host machine:
 - Database. Postgres


Copy the `src/Feed.WebApi/appsettings.Example.json` file and rename it to `src/Feed.WebApi/appsettings.Development.json`.
Replace the environment variables in the `src/Feed.WebApi/appsettings.Development.json` file with your own values.
Then run the application using dotnet CLI `dotnet run` command.

### Using docker compose
Copy the `docker/compose.dev.example.yml` file and rename it to `docker/compose.dev.yml`.
Replace the environment variables in the `docker/compose.dev.yml` file with your own values.
Then use commands below to build and run the application.

#### Startup

##### Bash (Linux / macOS / Git Bash)

```bash
docker compose -p feed -f docker/compose.dev.yml build && \
docker compose -p feed -f docker/compose.dev.yml up -d && \
docker compose -p feed -f docker/compose.dev.yml logs -f
```

##### PowerShell

```powershell
docker compose -p feed -f docker/compose.dev.yml build
if ($LASTEXITCODE -eq 0) {
    docker compose -p feed -f docker/compose.dev.yml up -d
}
if ($LASTEXITCODE -eq 0) {
    docker compose -p feed -f docker/compose.dev.yml logs -f
}
```

##### Command Prompt (cmd.exe)

```cmd
docker compose -p feed -f docker/compose.dev.yml build ^
&& docker compose -p feed -f docker/compose.dev.yml up -d ^
&& docker compose -p feed -f docker/compose.dev.yml logs -f
```

---

#### Down

##### Bash

```bash
docker compose -p feed -f docker/compose.dev.yml down
```

##### PowerShell

```powershell
docker compose -p feed -f docker/compose.dev.yml down
```

##### Command Prompt (cmd.exe)

```cmd
docker compose -p feed -f docker/compose.dev.yml down
```
