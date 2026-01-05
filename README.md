# API Project

C# Web API сервис с подключением к PostgreSQL и готовым контроллером для работы с задачами.

## Структура проекта

- **Models/Task.cs** - Модель TaskItem для таблицы в БД
- **Controllers/TasksController.cs** - REST API контроллер для работы с задачами
- **Program.cs** - Настройка приложения и подключение к БД
- **Migrations/** - Миграции Entity Framework

## Таблица Tasks

Таблица уже создана в PostgreSQL со следующими полями:
- `Id` (int, Primary Key, Auto Increment)
- `Title` (varchar(200), Required)
- `Description` (varchar(1000), Optional)
- `IsCompleted` (boolean, Default: false)
- `CreatedAt` (timestamp)
- `UpdatedAt` (timestamp, nullable)

## API Endpoints

### GET /api/Tasks
Получить все задачи
```bash
GET http://localhost:5000/api/Tasks
```

### GET /api/Tasks/{id}
Получить задачу по ID
```bash
GET http://localhost:5000/api/Tasks/1
```

### POST /api/Tasks
Создать новую задачу
```bash
POST http://localhost:5000/api/Tasks
Content-Type: application/json

{
  "title": "Новая задача",
  "description": "Описание задачи",
  "isCompleted": false
}
```

### PUT /api/Tasks/{id}
Обновить задачу
```bash
PUT http://localhost:5000/api/Tasks/1
Content-Type: application/json

{
  "title": "Обновленный заголовок",
  "description": "Обновленное описание",
  "isCompleted": true
}
```

### DELETE /api/Tasks/{id}
Удалить задачу
```bash
DELETE http://localhost:5000/api/Tasks/1
```

## Запуск проекта

```bash
dotnet run
```

API будет доступен на:
- HTTP: `http://localhost:5000`
- HTTPS: `https://localhost:5001`
- Swagger UI: `https://localhost:5001/swagger`

## Примеры использования через curl

### Создать задачу
```bash
curl -X POST "http://localhost:5000/api/Tasks" \
  -H "Content-Type: application/json" \
  -d "{\"title\":\"Моя первая задача\",\"description\":\"Описание задачи\",\"isCompleted\":false}"
```

### Получить все задачи
```bash
curl "http://localhost:5000/api/Tasks"
```

### Обновить задачу
```bash
curl -X PUT "http://localhost:5000/api/Tasks/1" \
  -H "Content-Type: application/json" \
  -d "{\"title\":\"Обновленная задача\",\"isCompleted\":true}"
```

### Удалить задачу
```bash
curl -X DELETE "http://localhost:5000/api/Tasks/1"
```

