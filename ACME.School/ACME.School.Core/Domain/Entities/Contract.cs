using ACME.School.Core.Domain.Common;

namespace ACME.School.Core.Domain.Entities
{
    public class Contract : AuditableEntity
    {
        public Guid ContractId { get; set; }
        public DateTime InscriptionDate { get; set; }
        public Guid StudentId { get; set; }
        public Guid CourseId { get; set; }
        public Student Student { get; set; }
        public Course Course { get; set; }
        public bool Paid { get; set; }
    }
}
