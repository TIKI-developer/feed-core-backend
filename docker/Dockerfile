# ---------- base runtime ----------
FROM mcr.microsoft.com/dotnet/aspnet:10.0.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# ---------- build ----------
FROM mcr.microsoft.com/dotnet/sdk:10.0.100 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /repo

COPY ["Simul.IdentityService.slnx", "."]
COPY ["src/Simul.IdentityService.WebApi/Simul.IdentityService.WebApi.csproj",           "src/Simul.IdentityService.WebApi/"]
COPY ["src/Simul.IdentityService.Application/Simul.IdentityService.Application.csproj", "src/Simul.IdentityService.Application/"]
COPY ["src/Simul.IdentityService.Domain/Simul.IdentityService.Domain.csproj",           "src/Simul.IdentityService.Domain/"]
COPY ["src/Simul.IdentityService.Persistence/Simul.IdentityService.Persistence.csproj", "src/Simul.IdentityService.Persistence/"]
COPY ["src/Simul.IdentityService.Caching/Simul.IdentityService.Caching.csproj",         "src/Simul.IdentityService.Caching/"]
COPY ["src/Simul.IdentityService.Security/Simul.IdentityService.Security.csproj",       "src/Simul.IdentityService.Security/"]

RUN dotnet restore "Simul.IdentityService.slnx"

COPY . .

WORKDIR "/repo/src/Simul.IdentityService.WebApi"

# ---------- publish ----------
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Simul.IdentityService.WebApi.csproj" \
    -c $BUILD_CONFIGURATION \
    --no-restore \
    -o /app/publish \
    /p:UseAppHost=false

# ---------- production ----------
FROM base AS production
WORKDIR /app

RUN adduser --disabled-password --gecos "" appuser \
    && chown -R appuser:appuser /app
USER appuser

COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Simul.IdentityService.WebApi.dll"]

# ---------- development ----------
FROM mcr.microsoft.com/dotnet/sdk:10.0.100 AS development
WORKDIR /repo
EXPOSE 8080
EXPOSE 8081

# Копируем .csproj и restore — пакеты скачиваются в ~/.nuget/packages внутри образа.
# obj/ при этом создаётся в /repo/src, но volume перезапишет эту папку при старте —
# это нормально: dotnet watch сам восстановит obj/ используя закэшированные пакеты.
COPY ["Simul.IdentityService.slnx", "."]
COPY ["src/Simul.IdentityService.WebApi/Simul.IdentityService.WebApi.csproj",           "src/Simul.IdentityService.WebApi/"]
COPY ["src/Simul.IdentityService.Application/Simul.IdentityService.Application.csproj", "src/Simul.IdentityService.Application/"]
COPY ["src/Simul.IdentityService.Domain/Simul.IdentityService.Domain.csproj",           "src/Simul.IdentityService.Domain/"]
COPY ["src/Simul.IdentityService.Persistence/Simul.IdentityService.Persistence.csproj", "src/Simul.IdentityService.Persistence/"]
COPY ["src/Simul.IdentityService.Caching/Simul.IdentityService.Caching.csproj",         "src/Simul.IdentityService.Caching/"]
COPY ["src/Simul.IdentityService.Security/Simul.IdentityService.Security.csproj",       "src/Simul.IdentityService.Security/"]

RUN dotnet restore "Simul.IdentityService.slnx"

VOLUME ["/repo/src"]

WORKDIR "/repo/src/Simul.IdentityService.WebApi"

ENV ASPNETCORE_ENVIRONMENT=Development

# Без --no-restore: watch перегенерирует obj/ из кэша ~/.nuget/packages в образе
CMD ["dotnet", "watch", "run", "--urls=http://0.0.0.0:8080"]