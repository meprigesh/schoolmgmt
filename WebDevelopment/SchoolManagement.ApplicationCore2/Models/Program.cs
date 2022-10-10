namespace SchoolManagement.ApplicationCore.Models
{
    public class Program
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Stream { get; set; }
        public string Details { get; set; }
        public DateTime Established { get; set; }

        public List<Student> Students { get; set; }
        public List<Semester> Semesters { get; set; }
    }
}
