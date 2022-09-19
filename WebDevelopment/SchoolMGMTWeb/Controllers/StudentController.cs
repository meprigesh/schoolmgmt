using Microsoft.AspNetCore.Mvc;
using SchoolMGMTWeb.Data;
using SchoolMGMTWeb.Models;
using System.Security.Cryptography.X509Certificates;

namespace SchoolMGMTWeb.Controllers
{
    public class StudentController : Controller
    {
        //dependency injection of school context
        private SchoolContext db;
        public StudentController(SchoolContext db)
        {
            this.db = db;
        }


        //route to access list
        [HttpGet]
        public IActionResult List()
        {
            var students = db.Students.ToList();
            return View(students);
        }

        [HttpGet]
        public IActionResult Add()=>View();
        [HttpPost]
        public IActionResult Add(Student student)
        {
            db.Students.Add(student);
            db.SaveChanges();
            return RedirectToAction("List");
        }
        public IActionResult Edit(int id)
        {
            var student = db.Students.Find(id);
            return View (student);
        }
        [HttpPost]
        public IActionResult Edit(Student student)
        {
            db.Students.Update(student);
            db.SaveChanges();
            return RedirectToAction("List");
        }
        public IActionResult Delete(int id)
        {
            var student = db.Students.Find(id);
            db.Students.Remove(student);
            db.SaveChanges();
            return RedirectToAction("List");
        }
    }
}
