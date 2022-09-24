using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using SchoolMGMTWeb.Data;
using SchoolMGMTWeb.Models;
using System.Security.Cryptography.X509Certificates;
using System.Reflection;

namespace SchoolMGMTWeb.Controllers
{
    public class StudentController : Controller
    {
        //dependency injection of school context
        private SchoolContext db;
        private readonly IWebHostEnvironment hostEnvironment;
        public StudentController(SchoolContext db,IWebHostEnvironment hostEnvironment)
        {
            this.db = db;
            this.hostEnvironment = hostEnvironment;
        }


        //route to access list
        [HttpGet]
        public IActionResult List()
        {
            var students = db.Students.Where(student=>student.Active==true).ToList();
            return View(students);
        }

        [HttpGet]
        public IActionResult Add()=>View();

        //Code to add new data
        [HttpPost]
        public IActionResult Add(Student student)
        {
            //var image = student.Avater;
            student.ProfileImage = SaveProfileImage(student.Avater) ?? "Default.png";
            db.Students.Add(student);
            db.SaveChanges();

            return RedirectToAction("list");

           /* var imageDirectory = Path.Combine(hostEnvironment.WebRootPath, "profile-images");
            Directory.CreateDirectory(imageDirectory);

            var fileName = $"{Guid.NewGuid()}_{image.FileName}";


            string filePath = Path.Combine(imageDirectory, fileName);

            using (Stream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                image.CopyTo(fileStream);
            }

            student.ProfileImage = fileName;
            db.Students.Add(student);
            db.SaveChanges();
            return RedirectToAction("List");*/
        }

        private string?SaveProfileImage(IFormFile image)
        {
            if(image is null)
            {
                return null;
            }
            var imageDirectory = Path.Combine(hostEnvironment.WebRootPath, "profile-images");
            Directory.CreateDirectory(imageDirectory);
            var fileName = $"{Guid.NewGuid()}_{image.FileName}";
            string filePath = Path.Combine(imageDirectory, fileName);

            //saving directory
            using (Stream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                image.CopyTo(fileStream);
            }
            return fileName;
        }



        //code to edit existing data
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

        //code to delete data
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var student = db.Students.Find(id);
          //  db.Students.Remove(student);
           // db.SaveChanges();
            student.Active = false;
            db.SaveChanges();
            return RedirectToAction("List");
        }


        /*[HttpPost]
        public IActionResult Delete(Student student)
        {
            var s=db.Students.Find(student.Id);
            s.Active = false;//soft delete
            db.SaveChanges();
            return RedirectToAction("List");
        }*/
    }
}
