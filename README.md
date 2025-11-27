# Инструкция по запуску
1. Разверните PostgreSQL в Docker.
2. В командной строке введите команду docker run --name test-task -p 5432:5432 -e POSTGRES_PASSWORD=2616 -d postgres.
3. Откройте проект в IDE и примените миграцию, введя dotnet ef database update -p "TestTask.Data\TestTask.Data.csproj" -s "TestTask.API\TestTask.API.csproj".
4. Для запуска Swagger запустите проект TestTask.API.
