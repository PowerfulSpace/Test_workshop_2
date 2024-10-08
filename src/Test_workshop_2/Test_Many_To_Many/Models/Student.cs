namespace Test_Many_To_Many.Models
{
    public class Student
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public List<Course> Courses { get; set; } = new List<Course>();
    }
}
