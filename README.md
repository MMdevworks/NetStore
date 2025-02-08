<a id="readme-top"></a>

## About The Project: NetStore

An Asp.NET Ecommerce website.

<b>Project Objective:</b> FullStack application with ASP.NET using MVC architecture

### Built With
[![HTML5][html5-badge]][csharp-url]
[![CSS][css-badge]][css-url]
[![Bootstrap][bootstrap-badge]][bootstrap-url]</br>
[![JavaScript][javascript-badge]][javascript-url]</br>
[![Csharp][csharp-badge]][csharp-url]
[![ASP.NET][asp-net-badge]][asp-net-url]
[![Entity Framework][ef-badge]][ef-url]</br>
[![MSSQL][mssql-badge]][mssql-url]

### Notes

### Migrations
In package manager console Create/Update database:
>update-database

Migrate:
>add-migration <migration-name>

### Installation
1. Clone the repo
   ```nm
   > git clone https://github.com/MMdevworks/NetStore.git
   > cd NetCoreStore
   ```
3. Open the project
   ```
   Open the solution file (.sln) in Visual Studio 2022 or later.
   ```
4. Restore NuGet package dependancies
   ```
   In Visual Studio go to: 
		Tools > NuGet Package Manager > Manage NuGet Packages for Solution > Restore dependencies

   Packages Used:
    Microsoft.EntityFrameworkCore
    Microsoft.EntityFrameworkCore.SqlServer
    Microsoft.EntityFrameworkCore.Tools
   ```
5. Configure Database Connection
   ```
   In appsettings.json update ConnectionString:

   "ConnectionStrings": {
     "DefaultConnection": "Server=<YourServer>;Database=<DatabaseName>;Trusted_Connection=True;TrustServerCertificate=True"
   }
   ```
7. Build and run the project
   ```
   With a project selected, click Run or press F5 to run the application.
   ```

<p align="right">(<a href="#readme-top">Back to top</a>)</p>

[csharp-badge]: https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp&logoColor=white
[csharp-url]: https://learn.microsoft.com/en-us/dotnet/csharp/
[mssql-badge]: https://img.shields.io/badge/Microsoft%20SQL%20Server-CC2927?style=for-the-badge&logo=microsoft%20sql%20server&logoColor=white
[mssql-url]: https://www.microsoft.com/en-us/sql-server
[html5-badge]: https://img.shields.io/badge/HTML5-E34F26?style=for-the-badge&logo=html5&logoColor=white
[html5-url]: https://developer.mozilla.org/en-US/docs/Glossary/HTML5
[javascript-badge]: https://img.shields.io/badge/JavaScript-323330?style=for-the-badge&logo=javascript&logoColor=F7DF1E
[javascript-url]: https://developer.mozilla.org/en-US/docs/Web/JavaScript
[bootstrap-badge]: https://img.shields.io/badge/Bootstrap-563D7C?style=for-the-badge&logo=bootstrap&logoColor=white
[bootstrap-url]: https://getbootstrap.com/
[asp-net-badge]: https://img.shields.io/badge/ASP.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white
[asp-net-url]: https://dotnet.microsoft.com/apps/aspnet
[ef-badge]: https://img.shields.io/badge/Entity%20Framework-512BD4?style=for-the-badge&logo=dotnet&logoColor=white
[ef-url]: https://learn.microsoft.com/en-us/ef/
[css-badge]: https://img.shields.io/badge/CSS3-1572B6?style=for-the-badge&logo=css3&logoColor=white
[css-url]: https://developer.mozilla.org/en-US/docs/Web/CSS
