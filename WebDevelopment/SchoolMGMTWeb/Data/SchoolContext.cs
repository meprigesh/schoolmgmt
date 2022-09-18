using Microsoft.EntityFrameworkCore;
using SchoolMGMTWeb.Models;
using System.Data.SqlClient;

namespace SchoolMGMTWeb.Data
{
    public class SchoolContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseS
                qlServer(@"Data Source=(localdb)\schoollocaldb;Initial Catalog=testdb;Integrated Security=True");
        }
        public DbSet<Student> Students { get; set; }
            
            
    }
}
