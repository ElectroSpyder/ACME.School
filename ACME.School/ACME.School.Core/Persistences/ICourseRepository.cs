using ACME.School.Core.Domain.Entities;

namespace ACME.School.Core.Persistences
{
    public interface ICourseRepository : IAsyncRepository<Course>
    {
    }
}
