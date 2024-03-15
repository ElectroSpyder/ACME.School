
using ACME.School.Core.Models;

namespace ACME.School.Core.Features.Students.Commands.CreateStudent
{
    public class CreateStudentCommandReponse : BaseResponse
    {
        public CreateStudentCommandReponse() : base()
        {
        }
        public CreateStudentModel Student { get; set; } = default!;
    }
}
