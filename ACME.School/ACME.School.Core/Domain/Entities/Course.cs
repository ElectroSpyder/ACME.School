using ACME.School.Core.Domain.Common;

namespace ACME.School.Core.Domain.Entities
{
    public class Course : AuditableEntity
    {
        public Guid CourseId { get; set; }
        public string CourseName { get; set; } = string.Empty;
        public decimal CourseCost { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ICollection<Contract>? Contracts { get; set; }
    }
}
