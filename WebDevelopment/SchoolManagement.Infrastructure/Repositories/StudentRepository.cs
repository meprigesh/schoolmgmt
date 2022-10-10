using Microsoft.EntityFrameworkCore;
using SchoolManagement.ApplicationCore.Models;
using SchoolManagement.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Infrastructure.Repositories
{
    public class StudentRepository
    {
        private readonly SchoolContext db;
        public StudentRepository(SchoolContext db)
        {
            this.db = db;
        }

        public async Task<List<Student>>AllAsync(string searchText)
        {
            var students = await db.Students
                .Where(s=>s.Active==true&&(string.IsNullOrEmpty(searchText)
                ||s.FirstName.Contains(searchText)
                ||s.LastName.Contains(searchText)
                ||s.Email.Contains(searchText)))
                .Include(x=>x.Program)
                .ToListAsync();
            return students;
        }

        public Student Findasync(int id)
        {
            var student = db.Students.Where(x => x.Id == id).Include(x => x.Program).FirstOrDefault();
            return student;
        }


        public async Task<int> InserAsync(Student student)
        {
            await db.Students.AddAsync(student);
            var rowafffected = Commit();
            return rowafffected;
        }


        public int Update(Student student)
        {
            db.Students.Update(student);
            var rowaffected = Commit();
            return rowaffected;
        }
        public int Commit() => db.SaveChanges();
    }
}
