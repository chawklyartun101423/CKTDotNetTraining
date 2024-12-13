//// See https://aka.ms/new-console-template for more information
//using System.Data;
//using System.Data.SqlClient;

//Console.WriteLine("Hello, World!");

////C# <=> Database

////ADO.NET
////Dapper (ORM)
////EFCore/Entity Framework (ORM)

//// [ORM(Object Relational Mapper)
////-----------------------------------
//// C#=> sql query => can CRUD with C# code.
////obj from C# = Table from Database ]

////nuget
////ctrl + .

////max connection=100
////100= 99
////breakpoint F9
////line by line F10

////Ctr +K,Ctr +D for format display



//SQL injection


using CKTDotNetTraining;



//AdoExample adoExample = new AdoExample();
//adoExample.Create();
//adoExample.Read();
//adoExample.Edit();
//adoExample.Update();
//adoExample.Delete();

//DapperExample DapperExample = new DapperExample();
//DapperExample.Create("updatedap","updatedapper","updatedap");
//DapperExample.Edit(10);
//DapperExample.Update(4, "update4Dapper", "4UpdateDapper", "4UpdateDapper");
//DapperExample.Delete(7);

EFCoreExample eFCoreExample = new EFCoreExample();
//eFCoreExample.Read();
//eFCoreExample.Create("title","author","content");
//eFCoreExample.Create("eftitle","efauthor","efcontent");
//eFCoreExample.Edit(1);
//eFCoreExample.Update(1, "updatedTitle", "updatedauthor", "updatedcontent");
//eFCoreExample.Delete(1);
Console.ReadKey();






