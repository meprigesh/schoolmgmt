namespace SchoolMGMTWeb.Models
{
    public class Subject
    {
        public int Id{ get; set; }
        public string Name{ get; set; }
        public bool Optional { get; set; }
        public byte CreditHours { get; set; }
        public List<Semester> Semsters { get; set; }
    }
}
