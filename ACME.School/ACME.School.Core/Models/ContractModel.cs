namespace ACME.School.Core.Models
{
    public class ContractModel
    {
        public Guid ContractId { get; set; }
        public DateTime InscriptionDate { get; set; }

        public Guid CourseId { get; set; }
        public Guid StudentId { get; set; }

    }
}
