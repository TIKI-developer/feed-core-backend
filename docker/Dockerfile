# ---------- Базовый образ для запуска (Runtime) ----------
FROM mcr.microsoft.com/dotnet/aspnet:10.0.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# ---------- Этап сборки (Build) ----------
FROM mcr.microsoft.com/dotnet/sdk:10.0.100 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /repo

# Копируем файл решения
COPY ["Feed.slnx", "."]

# Копируем все .csproj файлы проектов
COPY ["src/Feed.WebApi/Feed.WebApi.csproj", "src/Feed.WebApi/"]
COPY ["src/Feed.Application/Feed.Application.csproj", "src/Feed.Application/"]
COPY ["src/Feed.Domain/Feed.Domain.csproj", "src/Feed.Domain/"]
COPY ["src/Feed.Persistence/Feed.Persistence.csproj", "src/Feed.Persistence/"]
COPY ["src/Feed.Security/Feed.Security.csproj", "src/Feed.Security/"]
COPY ["src/Feed.Shared/Feed.Shared.csproj", "src/Feed.Shared/"]
COPY ["src/Feed.Email/Feed.Email.csproj", "src/Feed.Email/"]

# Восстанавливаем зависимости
RUN dotnet restore "Feed.slnx"

# Копируем ВЕСЬ остальной код
COPY . .

# Переходим в папку с WebApi проектом
WORKDIR "/repo/src/Feed.WebApi"

# ---------- Этап публикации (Publish) ----------
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Feed.WebApi.csproj" \
    -c $BUILD_CONFIGURATION \
    --no-restore \
    -o /app/publish \
    /p:UseAppHost=false

# ---------- Финальный образ для PRODUCTION ----------
FROM base AS production
WORKDIR /app

# Создаем пользователя для безопасности
RUN adduser --disabled-password --gecos "" appuser \
    && chown -R appuser:appuser /app
USER appuser

# Копируем собранное приложение
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Feed.WebApi.dll"]

# ---------- Образ для РАЗРАБОТКИ (Development) ----------
FROM mcr.microsoft.com/dotnet/sdk:10.0.100 AS development
WORKDIR /repo
EXPOSE 8080
EXPOSE 8081

# Копируем файл решения
COPY ["Feed.slnx", "."]

# Копируем .csproj файлы
COPY ["src/Feed.WebApi/Feed.WebApi.csproj", "src/Feed.WebApi/"]
COPY ["src/Feed.Application/Feed.Application.csproj", "src/Feed.Application/"]
COPY ["src/Feed.Domain/Feed.Domain.csproj", "src/Feed.Domain/"]
COPY ["src/Feed.Persistence/Feed.Persistence.csproj", "src/Feed.Persistence/"]
COPY ["src/Feed.Security/Feed.Security.csproj", "src/Feed.Security/"]
COPY ["src/Feed.Shared/Feed.Shared.csproj", "src/Feed.Shared/"]
COPY ["src/Feed.Email/Feed.Email.csproj", "src/Feed.Email/"]

# Восстанавливаем зависимости
RUN dotnet restore "Feed.slnx"

# Создаем том для кода
VOLUME ["/repo/src"]

WORKDIR "/repo/src/Feed.WebApi"

# Устанавливаем переменную окружения для режима разработки
ENV ASPNETCORE_ENVIRONMENT=Development

# Запускаем с "горячей перезагрузкой"
CMD ["dotnet", "watch", "run", "--urls=http://0.0.0.0:8080"]