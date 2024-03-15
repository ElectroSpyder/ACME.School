namespace ACME.School.Core.Models
{
    public class StudentWithCoursesVm
    {
        public StudentModel Student { get; set; }
        public ICollection<CourseModel> Courses { get; set; }
    }
}
