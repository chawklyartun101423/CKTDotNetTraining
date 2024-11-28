using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKTDotNetTraining.Models;
using Microsoft.EntityFrameworkCore;

namespace CKTDotNetTraining
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                String connectionString= "Data Source=.;Initial Catalog=CKTDotNetTraining;User ID =sa;Password=sa;TrustServerCertificate=True";
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
        public DbSet<BlogDataModel> Blogs{ get; set; }
    }
}

