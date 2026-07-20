# Документация

Feed — это backend-платформа для агрегирования контента, построенная на .NET 10, ASP.NET Core и PostgreSQL.
Она периодически собирает публикации из нескольких внешних источников, нормализует и агрегирует данные и предоставляет к ним доступ через единый API.

# Развертывание

Проект поддерживает два основных сценария запуска:
- Локальный запуск на хост-машине
- Запуск через Docker Compose

## Предварительные требования

Перед началом убедитесь, что у вас есть:
- Docker Engine или Docker Desktop
- Docker Compose v2
- PostgreSQL, если вы хотите запускать приложение вне контейнеров
- .NET 10 SDK, если планируете запускать API локально без Docker

## 1. Подготовка переменных окружения

В репозитории уже есть готовые файлы Compose:
- [docker/compose.dev.yml](../../docker/compose.dev.yml)
- [docker/compose.prod.yml](../../docker/compose.prod.yml)

Редактировать их вручную не нужно. Они используют переменные окружения из отдельных файлов в корне проекта:
- [dev.env](../../dev.env) для разработки
- [prod.env](../../prod.env) для production

Чтобы настроить окружение:
1. Скопируйте [docker/example.env](../../docker/example.env) в [dev.env](../../dev.env) и [prod.env](../../prod.env).
2. Откройте нужный файл и заполните необходимые значения и секреты.
3. Не меняйте названия переменных, только их значения.

> Для разработки используйте dev.env, для production — prod.env.

## 2. Запуск локально на хост-машине

Если вы хотите запускать API напрямую на своей машине, убедитесь, что PostgreSQL доступен, и перед запуском загрузите переменные из подходящего env-файла в оболочку.

Пример:

```bash
dotnet run --project src/Feed.WebApi/Feed.WebApi.csproj
```

## 3. Запуск через Docker Compose

### Development

Запустите среду разработки:

```bash
docker compose --env-file dev.env -f docker/compose.dev.yml up -d --build
```

Просмотрите логи:

```bash
docker compose --env-file dev.env -f docker/compose.dev.yml logs -f
```

Остановите среду:

```bash
docker compose --env-file dev.env -f docker/compose.dev.yml down
```

### Production

Запустите production-среду:

```bash
docker compose --env-file prod.env -f docker/compose.prod.yml up -d --build
```

Просмотрите логи:

```bash
docker compose --env-file prod.env -f docker/compose.prod.yml logs -f
```

Остановите среду:

```bash
docker compose --env-file prod.env -f docker/compose.prod.yml down
```

## Примечания

- Compose-файлы уже настроены на чтение переменных из [dev.env](../../dev.env) и [prod.env](../../prod.env).
- Для production обязательно используйте сильные секреты и корректные учетные данные в [prod.env](../../prod.env).
- Если вы меняете значения переменных окружения, перезапустите соответствующие сервисы Compose.
