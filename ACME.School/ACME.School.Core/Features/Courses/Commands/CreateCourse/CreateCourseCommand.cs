using MediatR;

namespace ACME.School.Core.Features.Courses.Commands.CreateCourse
{
    public class CreateCourseCommand : IRequest<CreateCourseCommandResponse>
    {
        public string CourseName { get; set; } = string.Empty;
        public decimal CourseCost { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}
