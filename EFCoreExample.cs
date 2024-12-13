using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKTDotNetTraining.Models;
using Microsoft.EntityFrameworkCore;

namespace CKTDotNetTraining
{
    public class EFCoreExample
    {
        public void Read()
        {
           AppDbContext db=new AppDbContext();
            var lst = db.Blogs.Where( x=>x.DeleteFlag == false).ToList(); //Need to add where clause before .ToList()

            // adding query after To list mean after retrieving from Database,then filter.
            foreach (var item in lst)
            {
                Console.WriteLine(item.BlogId);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);
            }

        }
        public void Create(string title, string author, string content)
        {
            BlogDataModel blog = new BlogDataModel
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content,
            };
            AppDbContext db = new AppDbContext();
            db.Blogs.Add(blog);
            var result= db.SaveChanges();
            Console.WriteLine(result==1 ? "Saving Successful" : "Saving Failed");
        }
        public void Edit(int id)
        {
            AppDbContext db=new AppDbContext();
            var item =db.Blogs.FirstOrDefault(x=>x.BlogId==id);
            //db.Blogs.Where(x=>x.BlogId==id).FirstOrDefault();

            if(item is null)
            {
                Console.WriteLine("No Data found");
    
            }
                Console.WriteLine(item.BlogId);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);
            
            
        }
        public void Update(int id, string author, string title,string content)
        {

            AppDbContext db=new AppDbContext();
            var item =db.Blogs.FirstOrDefault(x => x.BlogId == id);

            if (item is null)
            {
                Console.WriteLine("No Data found");
            }

            if (!string.IsNullOrEmpty(author))
            {
                item.BlogAuthor= author;
            }
            if (!string.IsNullOrEmpty(title))
            {
                item.BlogTitle = title;
            }
            if (!string.IsNullOrEmpty(content))
            {
                item.BlogContent = content;
            }
            var result= db.SaveChanges();
            Console.WriteLine(result ==1 ? "Updating Success" : "Updated Failed");
        }
        public void Delete(int id)
        {

            AppDbContext db=new AppDbContext();
            var item = db.Blogs
                .AsNoTracking()
                .FirstOrDefault( x => x.BlogId == id);
            if (item is null)
            {
                Console.WriteLine("No Data found");
                return;
            }
            db.Entry(item).State = EntityState.Deleted;
            var result= db.SaveChanges();
            Console.WriteLine(result == 1? "Deleting Successful" : " deleting Failed");
        }
    }
}
