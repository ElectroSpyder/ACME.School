using ACME.School.Core.Domain.Entities;
using ACME.School.Core.Features.Students.Queries.GetStudentWithCourses;
using ACME.School.Core.Models;
using ACME.School.Core.Persistences;
using ACME.School.Core.Profiles;
using ACME.School.Core.Repositories;
using ACME.School.Core.Tests.Mocks;
using AutoMapper;
using Moq;
using Shouldly;
using Xunit;

namespace ACME.School.Core.Tests.Students.Queries.GetStudentWithCourse
{
    public class GetStudentWithCourseHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IStudentRepository> _studentRepository;
        private readonly Mock<IContractRespository> _contractRespository;
        private readonly Mock<ICourseRepository> _courseRepository;
        public GetStudentWithCourseHandlerTest()
        {
            _contractRespository = RepositoryMock.GetContractRespository();
            _studentRepository = RepositoryMock.GetStudentRepository();
            _courseRepository = RepositoryMock.GetCourseRepository();

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task GetStudentWithCourseTest()
        {
            var handler = new GetStudentWithCourseQueryHandler(_contractRespository.Object,_studentRepository.Object,_courseRepository.Object, _mapper);
            var result = await handler.Handle(new GetStudentWithCourseQuery { StartDate = DateTime.Now, EndDate = DateTime.Now }, CancellationToken.None);
            result.ShouldBeOfType<List<StudentWithCoursesVm>>();

            //var resultWithCourses = await _contractRespository.Object.GetAllContractsInRangeDate(DateTime.Now.AddDays(-82), DateTime.Now.AddDays(40));

            //resultWithCourses.ShouldNotBeNull();
        }
    }
}
