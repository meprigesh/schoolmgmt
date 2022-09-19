using Microsoft.EntityFrameworkCore;
using SchoolMGMTWeb.Models;
using System.Data.SqlClient;

namespace SchoolMGMTWeb.Data
{
    public class SchoolContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;Initial Catalog=SchoolManagementDb;Integrated Security=True");
        }
        public DbSet<Student> Students { get; set; }     
    }
}
