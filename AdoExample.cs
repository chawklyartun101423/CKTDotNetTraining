using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace CKTDotNetTraining
{
    public class AdoExample   //
    {
        private readonly string _connectionString = "Data Source=.;Initial Catalog=CKTDotNetTraining;User ID=sa;Password=sa;";
        public void Read()
        {

            Console.WriteLine("Connection String" + _connectionString);
            SqlConnection connectionString = new SqlConnection(_connectionString);
            connectionString.Open();

            Console.WriteLine("Connection opened");

            string query = @"SELECT [BlogId]
                  ,[BlogTitle]
                  ,[BlogAuthor]
                  ,[BlogContent]
              FROM [dbo].[Tble_Blog]";      //for multiline support,should add "@" front of whole query. 
            SqlCommand cmd = new SqlCommand(query, connectionString);   // create command and add query within command
            //SqlDataAdapter adapter = new SqlDataAdapter(cmd);    //create Adapter to accept the query within command
            //DataTable dt = new DataTable();
            ////fetch data as table from SQL Database

            //adapter.Fill(dt);
            // Fill is same function as execute in SQL Server

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(reader["BlogId"]);
                Console.WriteLine(reader["BlogTitle"]);
                Console.WriteLine(reader["BlogAuthor"]);
                Console.WriteLine(reader["BlogContent"]);
            }

            Console.WriteLine("Connection Closing");
            connectionString.Close();
            Console.WriteLine("Connection Closed");
            //DataSet 
            //DataTable
            //DataRow
            //DataColumn

            //foreach (DataRow dr in dt.Rows)
            //{
            //    Console.WriteLine(dr["BlogId"]);
            //    Console.WriteLine(dr["BlogTitle"]);
            //    Console.WriteLine(dr["BlogAuthor"]);
            //    Console.WriteLine(dr["BlogContent"]);

            //}



            return;
        }
        public void Create()
        {
            Console.WriteLine("Blog Title");
            String title = Console.ReadLine();

            Console.WriteLine("Blog Author");
            String author = Console.ReadLine();

            Console.WriteLine("Blog Content");
            String content = Console.ReadLine();


            SqlConnection connectionString = new SqlConnection(_connectionString);

            //string queryInsert = $@"INSERT INTO [dbo].[Tbl_Blog]
            //           ([BlogTitle]
            //           ,[BlogAuthor]
            //           ,[BlogContent])
            //     VALUES
            //           ('{title}' 
            //		   ,'{author}'
            //		   ,'{content}')"; // avoid this method,should use with parameter

            string queryInsert = $@"INSERT INTO [dbo].[Tble_Blog]
          ([BlogTitle]
          ,[BlogAuthor]
          ,[BlogContent])
             VALUES
          (@BlogTitle 
	      ,@BlogAuthor
		   ,@BlogContent)"; // use with parameter



            SqlCommand cmd2 = new SqlCommand(queryInsert, connectionString);
            cmd2.Parameters.AddWithValue("@BlogTitle", title);
            cmd2.Parameters.AddWithValue("@BlogAuthor", author);
            cmd2.Parameters.AddWithValue("@BlogContent", content);

            //SqlDataAdapter adapter = new SqlDataAdapter(cmd2);// for read data from database
            //DataTable dt= new DataTable();
            //adapter.Fill(dt);


            if (connectionString.State != ConnectionState.Open)
            {
                connectionString.Open();
            }

            int result = cmd2.ExecuteNonQuery();  // run the query and return integer value



            connectionString.Close();

            Console.WriteLine(result == 1 ? "Saving Successful" : "Saving Failed");

        }
        public void Edit()
        {
            Console.WriteLine("Blog Id:");
            string id = Console.ReadLine();
            SqlConnection connectionString = new SqlConnection(_connectionString);
            connectionString.Open();

            string query = @"SELECT [BlogId]
                 ,[BlogTitle]
                 ,[BlogAuthor]
                 ,[BlogContent]
                FROM [dbo].[Tble_Blog] where BlogId=@BlogId";

            SqlCommand cmd = new SqlCommand(query, connectionString);
            cmd.Parameters.AddWithValue("@BlogId", id);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);

            connectionString.Close();

            if (dt.Rows.Count == 0)
            {
                Console.WriteLine("No Data found");
                return;
            }

            DataRow dr = dt.Rows[0];
            Console.WriteLine(dr["BlogId"]);
            Console.WriteLine(dr["BlogTitle"]);
            Console.WriteLine(dr["BlogAuthor"]);
            Console.WriteLine(dr["BlogContent"]);
        }
        public void Update()
        {
            Console.WriteLine("Blog ID");
            string id = Console.ReadLine();

            Console.WriteLine("Blog Title");
            String title = Console.ReadLine();


            Console.WriteLine("Blog Author");
            String author = Console.ReadLine();

            Console.WriteLine("Blog Content");
            String content = Console.ReadLine();
            SqlConnection connectionString = new SqlConnection(_connectionString);

            string queryInsert = $@"UPDATE [dbo].[Tble_Blog]
   SET [BlogTitle] = @BlogTitle,
      [BlogAuthor] = @BlogAuthor
      ,[BlogContent] = @BlogContent
 WHERE BlogId=@BlogId"; // use with parameter



            SqlCommand cmd2 = new SqlCommand(queryInsert, connectionString);
            cmd2.Parameters.AddWithValue("@BlogId", id);
            cmd2.Parameters.AddWithValue("@BlogTitle", title);
            cmd2.Parameters.AddWithValue("@BlogAuthor", author);
            cmd2.Parameters.AddWithValue("@BlogContent", content);
            if (connectionString.State == ConnectionState.Closed)
            {
                connectionString.Open();
            }

            int result = cmd2.ExecuteNonQuery();  // run the query and return integer value

            connectionString.Close();

            Console.WriteLine(result == 1 ? "Updating Successful" : "Updating Failed");

        }
        public void Delete()
        {
            Console.WriteLine("Blog ID");
            string id = Console.ReadLine();

            SqlConnection connectionString = new SqlConnection(_connectionString);

            string queryInsert = $@"DELETE FROM [dbo].[Tble_Blog]
      WHERE BlogId=@BlogId"; // use with parameter



            SqlCommand cmd2 = new SqlCommand(queryInsert, connectionString);

            cmd2.Parameters.AddWithValue("@BlogId", id);
            if (connectionString.State == ConnectionState.Closed)
            {
                connectionString.Open();
            }

            int result = cmd2.ExecuteNonQuery();  // run the query and return integer value

            connectionString.Close();

            Console.WriteLine(result == 1 ? "Deleting Successful" : "Deleting Failed");
        }
    }
}
