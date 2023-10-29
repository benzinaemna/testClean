using MediatR;

namespace Test.Application.Features.Student.Commands.DeleteStudent;

public record DeleteStudentCommand(int id):IRequest;
