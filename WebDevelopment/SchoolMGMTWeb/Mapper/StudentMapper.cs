using SchoolMGMTWeb.Models;
using SchoolMGMTWeb.ViewModel;

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
                Program = student.Program,
                Semester = student.Semester
            };
            return studentViewModel;
        }


        public static List<StudentViewModel>ToViewModel(this List<Student> students)
        {
            var studentViewModels=students.Select(x=>ToViewModel(x)).ToList();
            return studentViewModels;
        }

    }
}
