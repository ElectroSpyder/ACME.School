using ACME.School.Core.Features.Courses.Commands.CreateCourse;
using ACME.School.Core.Persistences;
using ACME.School.Core.Profiles;
using ACME.School.Core.Tests.Mocks;
using AutoMapper;
using Moq;
using Shouldly;
using Xunit;

namespace ACME.School.Core.Tests.Courses.Commands.CreateCourse
{
    public class CreateCourseQueryHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<ICourseRepository> _mockCourseRepository;

        public CreateCourseQueryHandlerTest()
        {
            _mockCourseRepository = RepositoryMock.GetCourseRepository();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public  async Task Handle_ValidCourse_AddToCourseRepository()
        {
            var handler = new CreateCourseCommandHandler(_mockCourseRepository.Object, _mapper);
            await handler.Handle(new CreateCourseCommand()
            {
                CourseName = "Flujo de Datos",
                StartDate = DateTime.Today,
                EndDate = DateTime.Today.AddDays(15),
                CourseCost = 4000m
            }, CancellationToken.None);

            var allCourses = await _mockCourseRepository.Object.ListAllAsync();
            allCourses.Count.ShouldBe(3);
        }

    }
}
