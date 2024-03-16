using ACME.School.Core.Domain.Entities;
using ACME.School.Core.Persistences;
using FluentValidation;

namespace ACME.School.Core.Features.Students.Commands.CreateStudent
{
    public class CreateStudentCommandValidator: AbstractValidator<CreateStudentCommand>
    {
        private readonly IAsyncRepository<Student> _studentRepository;

        public CreateStudentCommandValidator(IAsyncRepository<Student> studentRepository)
        {
            _studentRepository = studentRepository;
            RuleFor(x => x.Age).NotEmpty()
                .NotNull()
                .Must(x => x > 17)
                .WithMessage("Only people of legal age can register");
        }
    }
}
