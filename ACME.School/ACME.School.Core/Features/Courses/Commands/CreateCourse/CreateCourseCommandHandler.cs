using ACME.School.Core.Domain.Entities;
using ACME.School.Core.Models;
using ACME.School.Core.Persistences;
using AutoMapper;
using MediatR;

namespace ACME.School.Core.Features.Courses.Commands.CreateCourse
{
    public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand, CreateCourseCommandResponse>
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;

        public CreateCourseCommandHandler(ICourseRepository courseRepository, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
        }

        public async Task<CreateCourseCommandResponse> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {
            var response = new CreateCourseCommandResponse();
            var validator = new CreateCourseCommandValidator(_courseRepository);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (validationResult.Errors.Count > 0)
            {
                response.Success = false;
                response.ValidationErrors = [];
                foreach (var error in validationResult.Errors)
                {
                    response.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            if(response.Success)
            {
                var course = new Course
                {
                    CourseName = request.CourseName,
                    StartDate = request.StartDate,
                    EndDate = request.EndDate,
                    CourseCost = request.CourseCost
                };
                course = await _courseRepository.AddAsync(course);
                response.Course = _mapper.Map<CreateCourseModel>(course);
            }

            return response;
        }
    }
}
