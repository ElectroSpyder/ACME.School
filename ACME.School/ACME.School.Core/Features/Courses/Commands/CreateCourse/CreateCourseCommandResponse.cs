using ACME.School.Core.Models;

namespace ACME.School.Core.Features.Courses.Commands.CreateCourse
{
    public class CreateCourseCommandResponse : BaseResponse
    {
        public CreateCourseCommandResponse() : base()
        {
        }
        public CreateCourseModel Course { get; set; } = default!;
    }
}
