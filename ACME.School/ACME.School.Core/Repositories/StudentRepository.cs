using ACME.School.Core.Domain.Context;
using ACME.School.Core.Domain.Entities;
using ACME.School.Core.Persistences;

namespace ACME.School.Core.Repositories
{
    public class StudentRepository : BaseRepository<Student>, IStudentrepository
    {
        public StudentRepository(SqlDbContext context) : base(context)
        {
            
        }
    }
}
