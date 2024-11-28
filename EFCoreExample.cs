using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKTDotNetTraining.Models;

namespace CKTDotNetTraining
{
    public class EFCoreExample
    {
        public void Read()
        {
            AppDbContext db = new AppDbContext();
            var lst = db.Blogs.Where(x => x.BlogAuthor == "updatedapper").ToList();// C# code turn into Query , a bit complex than Dapper which is used Query Language directly
            foreach (var item in lst)
            {
                Console.WriteLine(item.BlogId);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);
            }
        }
        public void Create(string title,string author,string content) 
        {
            BlogDataModel blog=new BlogDataModel();
            {
               BlogTitle = title;
               BlogAuthor = author;
               BlogContent = content;

            }
            AppDbContext db = new AppDbContext();
            db.Blogs.Add(blog);
            var result=db.SaveChanges();
            
           
        
        }
    }
}
