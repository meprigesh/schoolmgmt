using Microsoft.EntityFrameworkCore;

namespace SchoolManagement.Data
{
    public class SchoolContext
    {
        public class SchoolContext : DbContext
        {
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder
                    .UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;Initial Catalog=SchoolManagementDb;Integrated Security=True");
            }
            public DbSet<Student> Students { get; set; }

        }
    }
}
