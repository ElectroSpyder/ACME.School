using ACME.School.Core.Domain.Context;
using ACME.School.Core.Domain.Entities;
using ACME.School.Core.Persistences;

namespace ACME.School.Core.Repositories
{
    public class CourseRepository : BaseRepository<Course>, ICourseRepository
    {
        public CourseRepository(SqlDbContext context) : base(context)
        {
            
        }
    }
}
