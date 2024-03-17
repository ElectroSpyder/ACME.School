using ACME.School.Core.Domain.Entities;
using ACME.School.Core.Features.Students.Commands.CreateStudent;
using ACME.School.Core.Persistences;
using ACME.School.Core.Profiles;
using ACME.School.Core.Tests.Mocks;
using AutoMapper;
using Moq;
using Shouldly;
using Xunit;

namespace ACME.School.Core.Tests.Students.Commands.CreateStudent
{
    public class CreateStudentCommandHundlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IStudentRepository> _studentRepositoryMock;

        public CreateStudentCommandHundlerTest()
        {
            _studentRepositoryMock = RepositoryMock.GetStudentRepository();

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task Handle_ValidStudent_AddToStudentRepository()
        {
            var handler = new CreateStudentCommandHandler(_studentRepositoryMock.Object, _mapper);

            await handler.Handle(new CreateStudentCommand() 
            {
                FirstName = "Patricia", 
                LastName = "Apaza", 
                Age = 45
            }, CancellationToken.None);

            var allStudet = await _studentRepositoryMock.Object.ListAllAsync();
            allStudet.Count.ShouldBe(3);
        }
    }
}
