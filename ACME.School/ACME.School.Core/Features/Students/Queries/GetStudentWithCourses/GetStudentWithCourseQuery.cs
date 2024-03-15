using ACME.School.Core.Models;
using MediatR;

namespace ACME.School.Core.Features.Students.Queries.GetStudentWithCourses
{
    public class GetStudentWithCourseQuery : IRequest<List<StudentWithCoursesVm>>
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
