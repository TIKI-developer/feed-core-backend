# ---------- Базовый образ для запуска (Runtime) ----------
FROM mcr.microsoft.com/dotnet/aspnet:10.0.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# ---------- Общий этап сборки (Build) ----------
FROM mcr.microsoft.com/dotnet/sdk:10.0.100 AS build
WORKDIR /repo

# Копируем файл решения
COPY ["Feed.slnx", "."]

# Копируем .csproj всех проектов, включая плагины
COPY ["src/Feed.WebApi/Feed.WebApi.csproj", "src/Feed.WebApi/"]
COPY ["src/Feed.Application/Feed.Application.csproj", "src/Feed.Application/"]
COPY ["src/Feed.Domain/Feed.Domain.csproj", "src/Feed.Domain/"]
COPY ["src/Feed.Persistence/Feed.Persistence.csproj", "src/Feed.Persistence/"]
COPY ["src/Feed.Security/Feed.Security.csproj", "src/Feed.Security/"]
COPY ["src/Feed.Shared/Feed.Shared.csproj", "src/Feed.Shared/"]
COPY ["src/Feed.Email/Feed.Email.csproj", "src/Feed.Email/"]
COPY ["src/Feed.Plugin.Abstractions/Feed.Plugin.Abstractions.csproj", "src/Feed.Plugin.Abstractions/"]
COPY ["src/Feed.Plugin.Host/Feed.Plugin.Host.csproj", "src/Feed.Plugin.Host/"]
# Встроенные (builtin) плагины:
COPY ["src/Feed.Vk/Feed.Vk.csproj", "src/Feed.Vk/"]

# Восстанавливаем зависимости всего решения
RUN dotnet restore "Feed.slnx"

# Копируем весь остальной код
COPY . .

# ---------- Публикация core-приложения ----------
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "src/Feed.WebApi/Feed.WebApi.csproj" \
    -c $BUILD_CONFIGURATION \
    --no-restore \
    -o /app/publish \
    /p:UseAppHost=false

# ---------- Публикация встроенных плагинов ----------
FROM build AS publish-plugins
ARG BUILD_CONFIGURATION=Release

# Каждый builtin-плагин публикуется в свою папку внутри /app/plugins/builtin
RUN dotnet publish "src/Feed.Vk/Feed.Vk.csproj" \
    -c $BUILD_CONFIGURATION \
    --no-restore \
    -o /app/plugins/builtin/Feed.Vk \
    /p:UseAppHost=false

# При добавлении нового плагина добавь ещё один RUN, например:
# RUN dotnet publish "src/Feed.Instagram/Feed.Instagram.csproj" \
#     -c $BUILD_CONFIGURATION --no-restore \
#     -o /app/plugins/builtin/Feed.Instagram /p:UseAppHost=false

# ---------- Финальный образ PRODUCTION ----------
FROM base AS production
WORKDIR /app

RUN adduser --disabled-password --gecos "" appuser

COPY --from=publish /app/publish .
COPY --from=publish-plugins /app/plugins ./plugins

RUN chown -R appuser:appuser /app
USER appuser

ENTRYPOINT ["dotnet", "Feed.WebApi.dll"]

# ---------- DEV: core-приложение с hot reload ----------
FROM mcr.microsoft.com/dotnet/sdk:10.0.100 AS development
WORKDIR /repo
EXPOSE 8080
EXPOSE 8081

# Копируем .csproj для восстановления зависимостей
COPY ["Feed.slnx", "."]
COPY ["src/Feed.WebApi/Feed.WebApi.csproj", "src/Feed.WebApi/"]
COPY ["src/Feed.Application/Feed.Application.csproj", "src/Feed.Application/"]
COPY ["src/Feed.Domain/Feed.Domain.csproj", "src/Feed.Domain/"]
COPY ["src/Feed.Persistence/Feed.Persistence.csproj", "src/Feed.Persistence/"]
COPY ["src/Feed.Security/Feed.Security.csproj", "src/Feed.Security/"]
COPY ["src/Feed.Shared/Feed.Shared.csproj", "src/Feed.Shared/"]
COPY ["src/Feed.Email/Feed.Email.csproj", "src/Feed.Email/"]
COPY ["src/Feed.Plugin.Abstractions/Feed.Plugin.Abstractions.csproj", "src/Feed.Plugin.Abstractions/"]
COPY ["src/Feed.Plugin.Host/Feed.Plugin.Host.csproj", "src/Feed.Plugin.Host/"]
COPY ["src/Feed.Vk/Feed.Vk.csproj", "src/Feed.Vk/"]

RUN dotnet restore "src/Feed.WebApi/Feed.WebApi.csproj"

VOLUME ["/repo/src"]

WORKDIR "/repo/src/Feed.WebApi"

ENV ASPNETCORE_ENVIRONMENT=Development

CMD ["dotnet", "watch", "run", "--urls=http://0.0.0.0:8080"]

# ---------- DEV: пересборка builtin-плагинов в watch-режиме ----------
FROM mcr.microsoft.com/dotnet/sdk:10.0.100 AS plugins-development
WORKDIR /repo

# Копируем только необходимые .csproj для плагинов и общих абстракций
COPY ["Feed.slnx", "."]
COPY ["src/Feed.Plugin.Abstractions/Feed.Plugin.Abstractions.csproj", "src/Feed.Plugin.Abstractions/"]
COPY ["src/Feed.Vk/Feed.Vk.csproj", "src/Feed.Vk/"]

RUN dotnet restore "src/Feed.Vk/Feed.Vk.csproj"

VOLUME ["/repo/src"]

# Список builtin-плагинов, которые нужно пересобирать в dev
ENV PLUGIN_PROJECTS="Feed.Vk"

# Запускаем отдельный dotnet watch build для каждого плагина
CMD sh -c 'for name in $PLUGIN_PROJECTS; do \
      (cd /repo/src/$name && dotnet restore && dotnet watch build -o "/repo/plugins/builtin/$name" --non-interactive &) ; \
    done; \
    while true; do sleep 30; done'