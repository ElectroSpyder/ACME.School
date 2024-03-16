namespace ACME.School.Core.Models
{
    public class CreateCourseModel
    {
        public string CourseName { get; set; } = string.Empty;
        public decimal CourseCost { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
