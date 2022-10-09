using SchoolMGMTWeb.Models;
using SchoolMGMTWeb.ViewModel;
using System.Net;
using System;

namespace SchoolMGMTWeb.Mapper
{
    public static class StudentMapper
    {

        public static StudentViewModel ToViewModel(this Student student)
        {
            var studentViewModel = new StudentViewModel
            {
                Active = student.Active,
                Address = student.Address,
                ProfileImage = student.ProfileImage,
                Email = student.Email,
                Dob = student.Dob,
                Gender = student.Gender,
                Phone = student.Phone,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Name = $"{student.FirstName} {student.LastName}",
                Id = student.Id,
                Program = student.Program.Name,
                Semester = student.Semester
            };
            return studentViewModel;
        }


        public static List<StudentViewModel>ToViewModel(this List<Student> students)
        {
            var studentViewModels=students.Select(x=>ToViewModel(x)).ToList();
            return studentViewModels;
        }

        public static Student ToModel(this StudentViewModel studentViewModel)
        {
            var student = new Student()
            {
                FirstName = studentViewModel.FirstName,
                LastName = studentViewModel.LastName,
                Active = studentViewModel.Active,
                Address = studentViewModel.Address,
                Email = studentViewModel.Email,
                Dob = studentViewModel.Dob,
                Gender = studentViewModel.Gender,
                Phone = studentViewModel.Phone,
                Id = studentViewModel.Id,
                ProgramId = studentViewModel.ProgramId,
                Semester = studentViewModel.Semester 
            };
            return student;
        }
    }
}
