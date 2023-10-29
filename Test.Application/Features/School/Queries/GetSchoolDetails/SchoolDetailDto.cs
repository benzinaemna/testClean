using Test.Application.Features.Student.Queries.GetAllStudents;
using Test.Domain;

namespace Test.Application.Features.School.Queries.GetSchoolDetails;

public class SchoolDetailDto
{
    public int Id { get; set; }
    public string SchoolName { get; set; }
    public string SchoolAdress { get; set; }
    public ICollection<StudentDto> Students { get; set; }
}
