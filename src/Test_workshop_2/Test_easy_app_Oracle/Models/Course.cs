namespace Test_easy_app_Oracle.Models
{
    public class Course
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public List<Student> Students { get; set; } = new List<Student>();
    }
}
