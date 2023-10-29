using MediatR;

namespace Test.Application.Features.School.commands.DeleteSchool;

public record DeleteSchoolCommand(int id):IRequest;

