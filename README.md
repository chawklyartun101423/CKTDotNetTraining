# CKTDotNetTraining


oracle database ->there is no quick nolock , fetch commit data only
need to add commit otherwise no affected row.

----------------------------------------------------------------------
C#

need to be added.AsNoTracking

select * from tbl_blog with (nolock)// fetch commit data only

commit data/uncommit data

insert into

update tbl_blog

1-mg mg 1 
2-mg mg 2
3-mg mg 3 -mg mg 6
4-mg mg 4
5-mg mg 5

//weakpoint cannot get real-time data
efcore database first(manual,auto) / code first
Creating Table in C# and run commandline without creating table in database side.

dotnet ef dbcontext scaffold "Server=.;Database=CKTDotNetTraining;User Id=sa;Password=sa;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -o Models -c AppDbContext -f

API

HttpMethod
HttpStatusCode
Resquest/Response

ADO.NET 
Dapper
EFCore
Console App
Rest API (ASP.Net Core Web API)
-PostMan
-Http Method
-Http Status Code
-Swagger
_ORM
_Data Model
-Database first
-ASNoTracking
-DTO (Data Transfer Object)
-Nuget Package
-Class Library
-AppDbContext
-C# basic
-SQL Basic
-Visual Studio 2022 Installation
Microsoft SQL Server 2022
_SSMS (SQL Server Management System)
-Delete Flag

---------------------------------------------------
Backend API

data model(data access,database) 10 column
view model (frontend return data) 2 columns



