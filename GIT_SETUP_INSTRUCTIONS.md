# Инструкция по подключению проекта к GitHub

## Шаг 1: Установка Git

Если Git еще не установлен, скачайте и установите его:
1. Перейдите на https://git-scm.com/download/win
2. Скачайте установщик для Windows
3. Запустите установщик и следуйте инструкциям (можно использовать настройки по умолчанию)
4. После установки перезапустите терминал/PowerShell

## Шаг 2: Настройка Git (если еще не настроен)

Выполните следующие команды (замените на свои данные):

```powershell
git config --global user.name "Ваше Имя"
git config --global user.email "ваш.email@example.com"
```

## Шаг 3: Создание репозитория на GitHub

1. Войдите в свой аккаунт GitHub: https://github.com/iexeAndroid
2. Нажмите кнопку "New" или перейдите по ссылке: https://github.com/new
3. Назовите репозиторий: `APIProject`
4. Выберите "Public" или "Private" (на ваше усмотрение)
5. НЕ добавляйте README, .gitignore или лицензию (мы уже создали их)
6. Нажмите "Create repository"

## Шаг 4: Подключение и отправка кода

### Вариант 1: Использование автоматического скрипта

Запустите PowerShell скрипт:
```powershell
.\setup-git.ps1
```

### Вариант 2: Ручное выполнение команд

Выполните команды по порядку:

```powershell
# Инициализация Git репозитория
git init

# Добавление remote репозитория (замените на URL вашего репозитория)
git remote add origin https://github.com/iexeAndroid/APIProject.git

# Добавление всех файлов
git add .

# Создание первого коммита
git commit -m "Initial commit: C# API Project with PostgreSQL"

# Переименование ветки в main
git branch -M main

# Отправка кода в GitHub (потребуется авторизация)
git push -u origin main
```

## Шаг 5: Авторизация в GitHub

При выполнении `git push` вам будет предложено авторизоваться:
- Используйте Personal Access Token (рекомендуется)
- Или используйте GitHub CLI для авторизации

### Создание Personal Access Token:
1. Перейдите: https://github.com/settings/tokens
2. Нажмите "Generate new token" → "Generate new token (classic)"
3. Дайте токену имя (например, "APIProject")
4. Выберите срок действия
5. Отметьте scope: `repo` (полный доступ к репозиториям)
6. Нажмите "Generate token"
7. Скопируйте токен (он показывается только один раз!)
8. При `git push` используйте токен как пароль (username - ваш GitHub username)

## Альтернатива: Использование GitHub Desktop

Если предпочитаете графический интерфейс:
1. Установите GitHub Desktop: https://desktop.github.com/
2. Войдите в свой аккаунт GitHub
3. File → Add Local Repository → выберите папку проекта
4. Нажмите "Publish repository" в GitHub Desktop

## Проверка

После успешной отправки проверьте:
- Откройте https://github.com/iexeAndroid/APIProject
- Убедитесь, что все файлы загружены

