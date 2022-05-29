# AspNetCore

## Запуск решения

Прежде чем решение можно будет выполнить, обязательно запустите миграцию инфраструктуры сущностей.

### Проблемы миграции с DbContext

Первоначальная миграция может завершиться неудачей из-за того, что шаблон ASP.NET Core поставляется с предварительной миграцией для SQL Server.

При попытке запустить миграцию вы можете увидеть такие ошибки, как:
> System.NullReferenceException: ссылка на объект не указывает на экземпляр объекта. 
> System.InvalidOperationException: Не удается найти сопоставление с реляционным типом для свойства «Microsoft.AspNetCore.Identity.IdentityUser.TwoFactorEnabled» с типом CLR «bool».

Удалите всю папку «Migrations» и повторно создайте новые исходные миграции.

Создайте новую миграцию с помощью консоли диспетчера пакетов Visual Studio (из меню: Сервис -> Диспетчер пакетов NuGet -> Консоль диспетчера пакетов):
```
  PM>Add-Migration
```
Или из командной строки через DotNet CLI:
```
$ dotnet ef migrations add Initial
```
Запуск миграций Entity Framework

Выполните миграцию с помощью любой консоли диспетчера пакетов Visual Studio (из меню: Сервис -> Диспетчер пакетов NuGet -> Консоль диспетчера пакетов):
```
PM> Update-Database
```
Или из командной строки через DotNet CLI выполните следующую команду внутри каталога проекта, где находится файл .csproj :
```
$ dotnet ef database update
```
После запуска миграции создается база данных, и веб-приложение готово к запуску.

### Обновить appsettings.json и View/DB.cs
Настройте строку подключения в файлах appsettings.json и View/DB.cs проекта, заменив ```username```, ```password``` и ```dbname``` соответствующим образом:
```
"ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Username=username;Password=password;Database=dbname;"
},

 public static string connectionString = "Host=localhost;Username=username;Password=password;Database=dbname;"
```
