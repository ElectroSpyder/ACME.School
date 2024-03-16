using ACME.School.Core.Persistences;
using ACME.School.Core.Repositories;
using FluentValidation;

namespace ACME.School.Core.Features.Courses.Commands.CreateCourse
{
    public class CreateCourseCommandValidator : AbstractValidator<CreateCourseCommand>
    {
        private readonly ICourseRepository _courseRepository;

        public CreateCourseCommandValidator(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
            RuleFor(x => x.CourseName)
                .NotEmpty()
                .NotNull()
                .WithMessage("Must have Name");
            RuleFor(x=> x.CourseCost)
                .NotEmpty()
                .NotNull()
                .WithMessage("Must hace Price");
            RuleFor(x => x.StartDate)
                .NotEmpty()
                .NotNull()
                .WithMessage("Must have Start date");
            RuleFor(x => x.EndDate)
                .NotEmpty()
                .NotNull()
                .WithMessage("Must have End date");
        }
    }
}
