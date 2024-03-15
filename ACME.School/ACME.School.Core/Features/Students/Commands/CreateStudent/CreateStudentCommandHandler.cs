using ACME.School.Core.Domain.Entities;
using ACME.School.Core.Models;
using ACME.School.Core.Persistences;
using AutoMapper;
using MediatR;

namespace ACME.School.Core.Features.Students.Commands.CreateStudent
{
    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, CreateStudentCommandReponse>
    {
        private readonly IStudentrepository _studentRepository;
        private readonly IMapper _mapper;

        public CreateStudentCommandHandler(IStudentrepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        public async Task<CreateStudentCommandReponse> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var createStudentCommandResponse = new CreateStudentCommandReponse();
            var validator = new CreateStudentCommandValidator(_studentRepository);

            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if(validationResult.Errors.Count > 0)
            {
                createStudentCommandResponse.Success = false;
                createStudentCommandResponse.ValidationErrors = [];
                foreach (var error in validationResult.Errors)
                {
                    createStudentCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            if(createStudentCommandResponse.Success)
            {
                var student = new Student
                {
                    Age = request.Age,
                    FirstName = request.FirstName,
                    LastName = request.LastName
                };
                student = await _studentRepository.AddAsync(student);

                createStudentCommandResponse.Student = _mapper.Map<CreateStudentModel>(student);
            }

            return createStudentCommandResponse;
        }
    }
}
