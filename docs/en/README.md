# Documentation

Feed is a backend content aggregation platform built with .NET 10, ASP.NET Core, and PostgreSQL.
It periodically collects publications from multiple external sources, normalizes and aggregates the data, and exposes them through a unified API.

# Deployment

This project supports two main deployment options:
- Running the application locally on the host machine
- Running it with Docker Compose

## Prerequisites

Before starting, make sure you have:
- Docker Engine or Docker Desktop
- Docker Compose v2
- PostgreSQL if you want to run the application outside containers
- .NET 10 SDK if you plan to run the API locally without Docker

## 1. Prepare environment variables

The repository already contains ready-to-use Compose files:
- [docker/compose.dev.yml](../../docker/compose.dev.yml)
- [docker/compose.prod.yml](../../docker/compose.prod.yml)

You do not need to edit these files manually. They read configuration from environment variables provided through separate env files at the project root:
- [dev.env](../../dev.env) for development
- [prod.env](../../prod.env) for production

To configure the environment:
1. Copy [docker/example.env](../../docker/example.env) to [dev.env](../../dev.env) and [prod.env](../../prod.env).
2. Open the target env file and fill in the required values and secrets.
3. Keep the variable names unchanged.

> Use the dev file for development runs and the prod file for production runs.

## 2. Run locally on the host machine

If you want to run the API directly on your machine, make sure PostgreSQL is available and load the variables from the appropriate env file into your shell before starting the application.

Example:

```bash
dotnet run --project src/Feed.WebApi/Feed.WebApi.csproj
```

## 3. Run with Docker Compose

### Development

Start the development environment with a dedicated Compose project name:

```bash
docker compose -p feed-dev --env-file dev.env -f docker/compose.dev.yml up -d --build
```

View logs:

```bash
docker compose -p feed-dev --env-file dev.env -f docker/compose.dev.yml logs -f
```

Stop the environment:

```bash
docker compose -p feed-dev --env-file dev.env -f docker/compose.dev.yml down
```

### Production

Start the production environment with a separate Compose project name:

```bash
docker compose -p feed-prod --env-file prod.env -f docker/compose.prod.yml up -d --build
```

View logs:

```bash
docker compose -p feed-prod --env-file prod.env -f docker/compose.prod.yml logs -f
```

Stop the environment:

```bash
docker compose -p feed-prod --env-file prod.env -f docker/compose.prod.yml down
```

## Notes

- The Compose files are already configured to use environment variables from [dev.env](../../dev.env) and [prod.env](../../prod.env).
- Use distinct Compose project names such as `feed-dev` and `feed-prod` to avoid conflicts between development and production resources.
- For production, make sure to provide strong secrets and valid credentials in [prod.env](../../prod.env).
- If you change the environment values, restart the relevant Compose services.
