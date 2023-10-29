using Test.Application.Features.School.Queries.GetAllSchools;

namespace Test.Application.Features.Student.Queries.GetStudentDetails;

public class StudentDetailDto
{
    public string StudentName { get; set; }
    public int Age { get; set; }
    public DateTime BirthDate { get; set; }
    public int SchoolID { get; set; }
    public SchoolDto School { get; set; }
}
