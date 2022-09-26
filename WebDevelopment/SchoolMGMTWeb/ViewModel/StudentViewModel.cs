using System.ComponentModel.DataAnnotations;

namespace SchoolMGMTWeb.ViewModel
{
    public class StudentViewModel
    {
        public int Id { get; set; }
        [Required]
        [MinLength(2, ErrorMessage ="First name should be at least 2 charecter")]
        [Display(Name= "First Name")]
        public string FirstName { get; set; }


        [Required]
        [MinLength(2,ErrorMessage ="Last Name should be 2 charecter")]
        [Display(Name ="Last Name")]
        public string LastName { get; set; }


        public string Name { get; set; }
        public string Address { get; set; }

        [Required]
        public DateTime Dob { get; set; }

        [Required]
        public char Gender { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "*")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "*")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "*")]
        public string Program { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "*")]
        public string Semester { get; set; }
        public bool Active { get; set; }
        public IFormFile Avater { get; set; }
        public string ProfileImage { get; set; }
    }
}
