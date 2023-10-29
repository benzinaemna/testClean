using MediatR;

namespace Test.Application.Features.School.commands.CreateSchool;

public record CreateSchoolCommand(string SchoolName, string SchoolAdress) :IRequest;
