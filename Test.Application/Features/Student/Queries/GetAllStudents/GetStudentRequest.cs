using MediatR;

namespace Test.Application.Features.Student.Queries.GetAllStudents;

public record GetStudentRequest:IRequest<List<StudentDto>>;

