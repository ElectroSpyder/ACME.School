namespace ACME.School.Core.Models
{
    public class StudentModel
    {
        public Guid StudentId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int Age { get; set; }
        public ICollection<ContractModel>? Contracts { get; set; }
    }
}
