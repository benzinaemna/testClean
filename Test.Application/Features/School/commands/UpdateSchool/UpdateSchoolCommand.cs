using MediatR;

namespace Test.Application.Features.School.commands.UpdateSchool;

public record UpdateSchoolCommand(int Id , string SchoolName, string SchoolAdress) :IRequest;

