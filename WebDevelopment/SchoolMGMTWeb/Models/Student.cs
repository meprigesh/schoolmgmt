using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq.Expressions;

namespace SchoolMGMTWeb.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string  FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public DateTime Dob { get; set; }
        public string Phone { get; set; }
        public string Semester { get; set; }
        public char Gender { get; set; }
        public bool Active { get; set; } = true;
        public int ProgramId { get; set; }
        public Program Program { get; set; }


        // [NotMapped]
        //public IFormFile Avater { get; set; }
        public string ProfileImage { get; set; }
    }
}
