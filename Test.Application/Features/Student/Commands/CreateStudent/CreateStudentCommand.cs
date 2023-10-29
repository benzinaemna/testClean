using MediatR;

namespace Test.Application.Features.Student.Commands.CreateStudent;

public class CreateStudentCommand : IRequest
{
    public string StudentName { get; set; }
    public int Age { get; set; }
    public DateTime BirthDate { get; set; }
    public int SchoolID { get; set; }
   
}

