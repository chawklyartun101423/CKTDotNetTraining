using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using CKTDotNetTraining.Models;
using Dapper;

namespace CKTDotNetTraining
{
    public class DapperExample
    {
        // Dapper do not  require for open & close connection.

        private readonly string _connectionString = "Data Source=.;Initial Catalog=CKTDotNetTraining;User ID =sa;Password=sa";
        public void Read()
        {
            //using (IDbConnection db = new SqlConnection(_connectionString))
            //{
            //    string query = "select * from Tble_Blog"; // Table name is not case sensitive
            //    var lst = db.Query(query).ToList();
            //    foreach (var item in lst)
            //    {
            //        Console.WriteLine(item.BlogId);
            //        Console.WriteLine(item.BlogTitle);
            //        Console.WriteLine(item.BlogAuthor);
            //        Console.WriteLine(item.BlogContent);
            //    }

            //}
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string query = "select * from Tble_Blog"; // Table name is not case sensitive
                var lst = db.Query<BlogDataModel>(query).ToList();
                foreach (var item in lst)
                {
                    Console.WriteLine(item.BlogId);
                    Console.WriteLine(item.BlogTitle);
                    Console.WriteLine(item.BlogAuthor);
                    Console.WriteLine(item.BlogContent);
                }

            }


        }
        public void Create(string title, string author, string content)

        {
            string query = $@"
         INSERT INTO [dbo].[Tble_Blog]
         (    
          [BlogTitle],[BlogAuthor],[BlogContent]) VALUES(@BlogTitle,@BlogAuthor
           ,@BlogContent)";

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                int result = db.Execute(query, new BlogDataModel
                {
                    BlogTitle = title,
                    BlogAuthor = author,
                    BlogContent = content
                });

                Console.WriteLine(result == 1 ? "Saving Success" : "Saving Failed");
            }
        }
        public void Edit(int id)
        {
            //String query = "select * from tble_blog where BlogId=@BlogId;";

            String query = $@"SELECT[BlogId]
                          ,[BlogTitle]
                          ,[BlogAuthor]
                          ,[BlogContent]
                          FROM[dbo].[Tble_Blog]
                          WHERE BlogId = @BlogId";
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var item = db.Query<BlogDataModel>(query, new BlogDataModel
                { BlogId = id }).FirstOrDefault();
                if (item is null)
                {
                    Console.WriteLine("No data found.");
                }


                Console.WriteLine(item.BlogId);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);

            }

        }
        public void Update(int id, string title, string author, string content)
        {
            String query = $@"UPDATE [dbo].[Tble_Blog]
                   SET [BlogTitle] = @BlogTitle,
                   [BlogAuthor] = @BlogAuthor
                   ,[BlogContent] = @BlogContent
                   WHERE BlogId=@BlogId";
            using (IDbConnection db = new SqlConnection(_connectionString))
            {

                int result = db.Execute(query, new BlogDataModel
                {
                    BlogId = id,
                    BlogTitle = title,
                    BlogAuthor = author,
                    BlogContent = content
                });
                Console.WriteLine(result == 1 ? "Updating Success" : "Updating Failed");
            }

        }
        public void Delete(int id)
        {

            String query = $@"DELETE FROM [dbo].[Tble_Blog]
      WHERE BlogId = @BlogId";
            using(IDbConnection db=new SqlConnection(_connectionString))
            { 
                int result= db.Execute(query,new BlogDataModel
                 {
                    BlogId = id
                });
                Console.WriteLine(result == 1 ? "Deleting Success" : "Deleting Failed");
                
            }
        }

    }
}
