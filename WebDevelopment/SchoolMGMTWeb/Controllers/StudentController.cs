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
using SchoolManagement.Infrastructure.Repositories;

namespace SchoolMGMTWeb.Controllers
{
    public class StudentController : Controller
    {
        //dependency injection of school context
        private readonly StudentRepository studentRepository;
        private readonly ProgramRepository programRepository;
        private readonly IWebHostEnvironment hostEnvironment;
        public StudentController(StudentRepository studentRepository,IWebHostEnvironment hostEnvironment,ProgramRepository programRepository)
        {
            this.studentRepository = studentRepository;
            this.programRepository=programRepository;
            this.hostEnvironment = hostEnvironment;
        }


        //route to access list
        [HttpGet]
        public async Task<IActionResult> List(string searchText)
        {
            var students = await studentRepository.AllAsync(searchText);
            var studentsViewModels = students.ToViewModel();
            return View(studentsViewModels);
        }


        //get method to acces program for add
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var programs = await programRepository.All();
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
            await studentRepository.InserAsync(student);

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
            // var student = db.Students.Where(x => x.Id == id).Include(x => x.Program).FirstOrDefault();
            var student = studentRepository.Findasync(id);
            var studentViewModel=student?.ToViewModel();

            var programs = programRepository.All().Result;
            ViewData["programs"] = programs.Select(x =>
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
            studentRepository.Update(student);
            return RedirectToAction("List");
        }



        //code to delete data
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var student = studentRepository.Findasync(id);
            student.Active = false;
            return View(student?.ToViewModel());
        }


        [HttpPost]
        public IActionResult Delete(StudentViewModel studentViewModel)
        {
            var s=studentRepository.Findasync(studentViewModel.Id);
            s.Active = false;
            studentRepository.Commit();
            return RedirectToAction("List");
        }
    }
}
