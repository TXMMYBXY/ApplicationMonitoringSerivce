# MonitoringService

Мониторинг приложений: ASP.NET Core Web API + React SPA + PostgreSQL, развёрнутые в Docker.

## Содержание
- [MonitoringService](#monitoringservice)
  - [Содержание](#содержание)
  - [Стек](#стек)
  - [Структура репозитория](#структура-репозитория)
  - [Требования](#требования)
  - [Конфигурация](#конфигурация)
  - [Запуск](#запуск)
  - [Документация API](#документация-api)

## Стек

- Backend: ASP.NET Core 9.0 (`MonitoringService.Api` + слои Application/Infrastructure/Entities)
- Frontend: React + Vite (`application-monitoring-service`)
- База данных: PostgreSQL 16
- Инфраструктура: Docker + Docker Compose
- ORM: Entity Framework Core (миграции в `MonitoringService.Infrastructure`)

---


## Структура репозитория

```text
MonitoringService
└─ ApplicationMonitoringSerivce
   ├─ MonitoringService.Api
   │  ├─ Dockerfile          # билд и ран API
   │  └─ ...
   ├─ MonitoringService.Application      # Интерфейсы
   ├─ MonitoringService.Infrastructure   # DbContext + миграции EF, реализация
   ├─ MonitoringService.Entities         # Сущности, модели
   ├─ reactApp
   │  ├─ Dockerfile             # билд и ран фронта (Vite + nginx)
   │  └─ ...                    # исходники React
   ├─ .env.example              # шаблон файла окружения
   ├─ .env                      # локальный файл окружения (НЕ коммитить)
   ├─ README.md                 # этот файл
   └─ docker-compose.yml        # запуск всех контейнеров
```

## Требования
- Docker Desktop / Docker Engine + Docker Compose
- .NET SDK 9 (для локального запуска и миграций)
- Node.js 18+ (только если запускать фронт без Docker)
- EF CLI (если ещё не установлен):

## Конфигурация
.env.example - пример файла конфигурации. На основе него нужно создать рабочий файл с переменными окружения

## Запуск
1. Создать файл конфигурации:
    ```bash
    copy .env.example .env
    ```
    Важно: нельзя коммитить .env в систему контроля версий

2. Настроить `.env`, уточнить все данные
3. В корне проекта запустить сборку контейнеров:
    ```bash
    docker-compose up --build
    ```
4. Запустить миграции инциализации бд:
   ```bash
     dotnet ef database update `
    -p MonitoringService.Infrastructure `
    -s MonitoringService.Api
   ```
    При этом в логах могут быть такие сообщения, которые игнорируются, поскольку БД создается пустой. Таблица (__EFMigrationsHistory) существует только если хоть одна миграция уже была применена:
    ```bash
    fail: Microsoft.EntityFrameworkCore.Database.Command[20102]
      Failed executing DbCommand (37ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      SELECT "MigrationId", "ProductVersion"
      FROM "__EFMigrationsHistory"
      ORDER BY "MigrationId";
        ```

## Документация API
<details>
<summary>Документация:</summary>  

```json
{
  "openapi": "3.0.4",
  "info": {
    "title": "Сервис мониторинга стороннего приложения",
    "version": "v1"
  },
  "paths": {
    "/api/statistics/add-statistic": {
      "post": {
        "tags": [
          "Statistics"
        ],
        "requestBody": {
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/CreateStatisticViewModel"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/CreateStatisticViewModel"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/CreateStatisticViewModel"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "OK"
          }
        }
      }
    },
    "/api/statistics/get-all-statistics": {
      "get": {
        "tags": [
          "Statistics"
        ],
        "responses": {
          "200": {
            "description": "OK",
            "content": {
              "text/plain": {
                "schema": {
                  "type": "array",
                  "items": {
                    "$ref": "#/components/schemas/GetStatisticViewModel"
                  }
                }
              },
              "application/json": {
                "schema": {
                  "type": "array",
                  "items": {
                    "$ref": "#/components/schemas/GetStatisticViewModel"
                  }
                }
              },
              "text/json": {
                "schema": {
                  "type": "array",
                  "items": {
                    "$ref": "#/components/schemas/GetStatisticViewModel"
                  }
                }
              }
            }
          }
        }
      }
    },
    "/api/statistics/{deviceId}/get-all-statistics-by-device": {
      "get": {
        "tags": [
          "Statistics"
        ],
        "parameters": [
          {
            "name": "deviceId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "OK",
            "content": {
              "text/plain": {
                "schema": {
                  "type": "array",
                  "items": {
                    "$ref": "#/components/schemas/GetStatisticViewModel"
                  }
                }
              },
              "application/json": {
                "schema": {
                  "type": "array",
                  "items": {
                    "$ref": "#/components/schemas/GetStatisticViewModel"
                  }
                }
              },
              "text/json": {
                "schema": {
                  "type": "array",
                  "items": {
                    "$ref": "#/components/schemas/GetStatisticViewModel"
                  }
                }
              }
            }
          }
        }
      }
    },
    "/api/statistics/get-all-devices": {
      "get": {
        "tags": [
          "Statistics"
        ],
        "responses": {
          "200": {
            "description": "OK",
            "content": {
              "text/plain": {
                "schema": {
                  "type": "array",
                  "items": {
                    "$ref": "#/components/schemas/GetDeviceViewModel"
                  }
                }
              },
              "application/json": {
                "schema": {
                  "type": "array",
                  "items": {
                    "$ref": "#/components/schemas/GetDeviceViewModel"
                  }
                }
              },
              "text/json": {
                "schema": {
                  "type": "array",
                  "items": {
                    "$ref": "#/components/schemas/GetDeviceViewModel"
                  }
                }
              }
            }
          }
        }
      }
    },
    "/api/statistics/delete-statistic": {
      "delete": {
        "tags": [
          "Statistics"
        ],
        "requestBody": {
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/DeleteStatisticViewModel"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/DeleteStatisticViewModel"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/DeleteStatisticViewModel"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "OK"
          }
        }
      }
    }
  },
  "components": {
    "schemas": {
      "CreateStatisticViewModel": {
        "required": [
          "_id",
          "endTime",
          "name",
          "startTime",
          "version"
        ],
        "type": "object",
        "properties": {
          "_id": {
            "minLength": 1,
            "type": "string"
          },
          "name": {
            "maxLength": 255,
            "minLength": 1,
            "type": "string"
          },
          "startTime": {
            "type": "string",
            "format": "date-time"
          },
          "endTime": {
            "type": "string",
            "format": "date-time"
          },
          "version": {
            "minLength": 1,
            "type": "string"
          }
        },
        "additionalProperties": false
      },
      "DeleteStatisticViewModel": {
        "type": "object",
        "properties": {
          "id": {
            "type": "integer",
            "format": "int32"
          }
        },
        "additionalProperties": false
      },
      "GetDeviceViewModel": {
        "type": "object",
        "properties": {
          "_id": {
            "type": "string",
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "GetStatisticViewModel": {
        "type": "object",
        "properties": {
          "id": {
            "type": "integer",
            "format": "int32"
          },
          "_id": {
            "type": "string",
            "nullable": true
          },
          "name": {
            "type": "string",
            "nullable": true
          },
          "startTime": {
            "type": "string",
            "format": "date-time"
          },
          "endTime": {
            "type": "string",
            "format": "date-time"
          },
          "version": {
            "type": "string",
            "nullable": true
          }
        },
        "additionalProperties": false
      }
    }
  }
}
```

</details>

