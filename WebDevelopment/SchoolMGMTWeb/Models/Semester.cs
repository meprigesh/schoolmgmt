namespace SchoolMGMTWeb.Models
{
    public class Semester
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public double Fee { get; set; }
        public List<Program> Programs { get; set; }
        public List<Subject> Subjects { get; set; }
        
    }
}
