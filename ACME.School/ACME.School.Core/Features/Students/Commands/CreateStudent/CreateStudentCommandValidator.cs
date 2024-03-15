using ACME.School.Core.Persistences;
using FluentValidation;

namespace ACME.School.Core.Features.Students.Commands.CreateStudent
{
    public class CreateStudentCommandValidator: AbstractValidator<CreateStudentCommand>
    {
        private readonly IStudentrepository _studentRepository;

        public CreateStudentCommandValidator(IStudentrepository studentRepository)
        {
            _studentRepository = studentRepository;
            RuleFor(x => x.Age).NotEmpty()
                .NotNull()
                .Must(x => x > 17)
                .WithMessage("Only people of legal age can register");
        }
    }
}
