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
            var courses = new List<Course> {
                new()
                {
                     CourseName = "Curso de programación",
                     StartDate = Today.AddDays(-8),
                     EndDate = Today.AddDays(30),
                     CourseCost = 134.98m
                },
                new()
                {
                    CourseName = "Punteros",
                    StartDate = Today.AddDays(-20),
                    EndDate = Today.AddDays(15),
                    CourseCost = 500m
                }

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
        public static Mock<IAsyncRepository<Student>> GetStudentRepository()
        {
            var students = new List<Student>
            {
                new() {                   
                     FirstName = "Pedro",
                      LastName = "Gonzalez",
                       Age = 45,
                        Contracts = []
                },
                new() {                   
                     FirstName = "Maximo",
                      LastName = "Gonzalez",
                       Age = 28,
                       Contracts = []
                }
            };
            
            var mockStudentRepository = new Mock<IAsyncRepository<Student>>();
            mockStudentRepository.Setup(repo => repo.ListAllAsync()).ReturnsAsync(students);

            mockStudentRepository.Setup(repo => repo.AddAsync(It.IsAny<Student>())).ReturnsAsync(
                (Student student) =>
                {
                    students.Add(student);
                    return student;
                });

            return mockStudentRepository;
        }
    }
}
