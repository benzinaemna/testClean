using MediatR;

namespace Test.Application.Features.Student.Commands.UpdateStudent;

public class UpdateStudentCommand:IRequest
{
    public int Id { get; set; }
    public string StudentName { get; set; }
    public int Age { get; set; }
    public DateTime BirthDate { get; set; }
    public int SchoolID { get; set; }
}
