$ dotnet add package Microsoft.EntityFrameworkCore
$ dotnet add package Microsoft.EntityFrameworkCore.Design
$ dotnet add package Microsoft.EntityFrameworkCore.SQLite  
dotnet tool install --global dotnet-ef
dotnet ef migrations add InitialCreate
dotnet ef database update
