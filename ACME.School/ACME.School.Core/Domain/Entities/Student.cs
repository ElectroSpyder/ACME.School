using ACME.School.Core.Domain.Common;

namespace ACME.School.Core.Domain.Entities
{
    public class Student : AuditableEntity
    {
        public Guid StudentId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int Age { get; set; }
        public ICollection<Contract>? Contracts { get; set; }
    }
}
