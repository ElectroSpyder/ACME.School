using Ardalis.GuardClauses;

namespace ACME.School.Core.Models
{
    public class CreateCourseModel(string courseName, decimal courseCost, 
                                    DateTime startDate, DateTime endDate)
    {
        public string CourseName { get; set; } = Guard.Against.NullOrWhiteSpace(courseName);
        public decimal CourseCost { get; set; } = Guard.Against.Negative(courseCost);
        public DateTime StartDate { get; set; } = Guard.Against.OutOfSQLDateRange(startDate);
        public DateTime EndDate { get; set; } = Guard.Against.OutOfSQLDateRange(endDate);
    }
}
