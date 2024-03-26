using Ardalis.GuardClauses;

namespace ACME.School.Core.Models
{
    public class CreateCourseModel
    {
        public string CourseName { get; set; } = string.Empty;
        public decimal CourseCost { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public CreateCourseModel(string courseName, decimal courseCost, DateTime startDate, DateTime endDate)
        {
            CourseName = Guard.Against.NullOrWhiteSpace(courseName);
            CourseCost = Guard.Against.Negative(courseCost);
            StartDate = Guard.Against.OutOfSQLDateRange(startDate);
            EndDate = Guard.Against.OutOfSQLDateRange(endDate);
        }
    }
}
