using ACME.School.Core.Domain.Entities;
using ACME.School.Core.Persistences;
using Moq;

namespace ACME.School.Core.Tests.Mocks
{
    public class RepositoryMock
    {
        public static DateTime Today { get { return DateTime.Now; }  }
        public static Mock<ICourseRepository> GetCourseRepository()
        {
            var courseOne = new Course
            {
                CourseId = Guid.Parse("789e4356-745f-4903-9515-aacf619c4e2c"),
                CourseName = "Curso de programación",
                StartDate = Today.AddDays(-8),
                EndDate = Today.AddDays(30),
                CourseCost = 134.98m
            };
            var courseDos = new Course
            {
                CourseId = Guid.Parse("3ade7b98-01e8-41bf-85c8-ad3039b81607"),
                CourseName = "Punteros",
                StartDate = Today.AddDays(-20),
                EndDate = Today.AddDays(15),
                CourseCost = 500m
            };
            var courses = new List<Course>
            {
                courseOne,
                courseDos
            };

            var mockCourseRepository = new Mock<ICourseRepository>();
            mockCourseRepository.Setup(repo => repo.ListAllAsync()).ReturnsAsync(courses);

            mockCourseRepository.Setup(repo => repo.AddAsync(It.IsAny<Course>())).ReturnsAsync(
                (Course course) =>
                {
                    courses.Add(course);
                    return course;
                });
            return mockCourseRepository;
        }
        public static Mock<IStudentRepository> GetStudentRepository()
        {
            var studentOne = new Student
            {
                StudentId = Guid.Parse("60dc1dc0-2634-46f8-a336-29334a15c994"),
                FirstName = "Pedro",
                LastName = "Gonzalez",
                Age = 45
            };

            var studentDos = new Student
            {
                StudentId = Guid.Parse("47bc7a85-abc6-4ab2-8ec6-2d97ca6a7bf8"),
                FirstName = "Pedro",
                LastName = "Gonzalez",
                Age = 45
            };

            var students = new List<Student>
            { 
                studentOne,
                studentDos              
            };
            
            var mockStudentRepository = new Mock<IStudentRepository>();
            mockStudentRepository.Setup(repo => repo.ListAllAsync()).ReturnsAsync(students);

            mockStudentRepository.Setup(repo => repo.AddAsync(It.IsAny<Student>())).ReturnsAsync(
                (Student student) =>
                {
                    students.Add(student);
                    return student;
                });

            return mockStudentRepository;
        }
                
        public static Mock<IContractRespository> GetContractRespository()
        {
            var courseOne = new Course
            {
                CourseId = Guid.Parse("789e4356-745f-4903-9515-aacf619c4e2c"),
                CourseName = "Curso de programación",
                StartDate = Today.AddDays(-8),
                EndDate = Today.AddDays(30),
                CourseCost = 134.98m
            };
            var courseDos = new Course
            {
                CourseId = Guid.Parse("3ade7b98-01e8-41bf-85c8-ad3039b81607"),
                CourseName = "Punteros",
                StartDate = Today.AddDays(-20),
                EndDate = Today.AddDays(15),
                CourseCost = 500m
            };
            var studentOne = new Student
            {
                StudentId = Guid.Parse("60dc1dc0-2634-46f8-a336-29334a15c994"),
                FirstName = "Pedro",
                LastName = "Gonzalez",
                Age = 45
            };

            var studentDos = new Student
            {
                StudentId = Guid.Parse("47bc7a85-abc6-4ab2-8ec6-2d97ca6a7bf8"),
                FirstName = "Pedro",
                LastName = "Gonzalez",
                Age = 45
            };

            var contracts = new List<Contract>
            {
                new()
                {
                     ContractId = Guid.Parse("47e58cd1-83b9-4d72-ae6e-cad73773f526"),
                      InscriptionDate = Today,
                      StudentId =Guid.Parse("60dc1dc0-2634-46f8-a336-29334a15c994"),
                      Student = studentOne,
                      CourseId =  Guid.Parse("789e4356-745f-4903-9515-aacf619c4e2c"),
                      Course = courseOne,
                      Paid = true
                },
                new()
                {
                    ContractId = Guid.Parse("097c0436-0a85-4f9c-a85f-f34a067d3252"),
                      InscriptionDate = Today,
                      StudentId = Guid.Parse("60dc1dc0-2634-46f8-a336-29334a15c994"),
                      Student = studentOne,
                      CourseId = Guid.Parse("3ade7b98-01e8-41bf-85c8-ad3039b81607"),
                      Course = courseDos,
                      Paid = true
                },
                new()
                {
                    ContractId = Guid.Parse("986d3fce-3b7b-4824-9e93-75c999a8892e"),
                     InscriptionDate = Today,
                     StudentId = Guid.Parse("47bc7a85-abc6-4ab2-8ec6-2d97ca6a7bf8"),
                     Student = studentDos,
                      CourseId = Guid.Parse("955cf327-e7ef-4766-bd98-a17fa4a07b10"),
                     Course = courseOne
                }

            };
            
            var mockContractRepository = new Mock<IContractRespository>();            

            mockContractRepository.Setup(repo =>
                repo.GetAllContractsInRangeDate(Today, Today)).ReturnsAsync(contracts);
            
            mockContractRepository.Setup(repo => repo.ListAllAsync()).ReturnsAsync(contracts);
            
            return mockContractRepository;
        }
    }
}
