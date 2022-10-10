using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using SchoolManagement.ApplicationCore.Models;
using System.Security.Cryptography.X509Certificates;
using System.Reflection;
using SchoolMGMTWeb.Mapper;
using SchoolMGMTWeb.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolManagement.Infrastructure.Data;

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
        public async Task<IActionResult> List()
        {
            var students = await db.Students.Where(student=>student.Active==true).Include(x=>x.Program).ToListAsync();
            var studentsViewModels = students.ToViewModel();
            return View(studentsViewModels);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var programs = await db.Programs.ToListAsync();
            ViewData["programs"] = programs.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();
            return View();
        }

        //Code to add new data
        [HttpPost]
        public async Task<IActionResult> Add(StudentViewModel studentViewModel)
        {
            //var image = student.Avater;
            var student = studentViewModel.ToModel();
            student.ProfileImage = SaveProfileImage(studentViewModel.Avater) ?? "Default.png";
            await db.Students.AddAsync(student);
            await db.SaveChangesAsync();

            return RedirectToAction("list");
        }

        private string?SaveProfileImage(IFormFile image)
        {
            if(image is null||image.Length<=0)
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
            var student = db.Students.Where(x => x.Id == id).Include(x => x.Program).FirstOrDefault();
            var studentViewModel=student?.ToViewModel();

            var program = db.Programs.ToList();
            ViewData["programs"] = program.Select(x =>
            new SelectListItem
            {
                Text=x.Name,
                Value=x.Id.ToString()
            }).ToList();
            return View (studentViewModel);
        }


        [HttpPost]
        public IActionResult Edit(StudentViewModel studentViewModel)
        {
            var student=studentViewModel.ToModel();
            student.ProfileImage=SaveProfileImage(studentViewModel.Avater)??studentViewModel.ProfileImage;
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
