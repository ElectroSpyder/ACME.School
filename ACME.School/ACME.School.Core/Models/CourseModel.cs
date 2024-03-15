namespace ACME.School.Core.Models
{
    public class CourseModel
    {
        public string CourseName { get; set; } = string.Empty;
        public decimal CourseCost { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ICollection<ContractModel>? Contracts { get; set; }
    }
}
