using Microsoft.EntityFrameworkCore;
using SchoolManagement.ApplicationCore.Models;

namespace SchoolManagement.Infrastructure.Data
{ 
    public class SchoolContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;Initial Catalog=SchoolManagementDb;Integrated Security=True");
        }
        public DbSet<Student> Students { get; set; }  
        public DbSet<Program> Programs  { get; set; }
        public DbSet<SchoolManagement.ApplicationCore.Models.Semester> Semester { get; set; }
    }
}
