# Скрипт для подключения проекта к GitHub и отправки кода
# Убедитесь, что Git установлен перед запуском этого скрипта

Write-Host "Инициализация Git репозитория..." -ForegroundColor Green
git init

Write-Host "Добавление remote репозитория..." -ForegroundColor Green
git remote add origin https://github.com/iexeAndroid/APIProject.git

Write-Host "Добавление всех файлов..." -ForegroundColor Green
git add .

Write-Host "Создание первого коммита..." -ForegroundColor Green
git commit -m "Initial commit: C# API Project with PostgreSQL"

Write-Host "Переименование ветки в main..." -ForegroundColor Green
git branch -M main

Write-Host "Отправка кода в GitHub..." -ForegroundColor Green
Write-Host "ВНИМАНИЕ: Вам нужно будет ввести учетные данные GitHub!" -ForegroundColor Yellow
git push -u origin main

Write-Host "Готово! Проект успешно отправлен в GitHub." -ForegroundColor Green

