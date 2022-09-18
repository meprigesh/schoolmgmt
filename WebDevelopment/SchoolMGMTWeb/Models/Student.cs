namespace SchoolMGMTWeb.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string  FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public DateTime Date { get; set; }
        public string Phone { get; set; }
        public string Program { get; set; }
        public string Semester { get; set; }
        public char Gender { get; set; }
    }
}
