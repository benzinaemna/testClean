using MediatR;

namespace Test.Application.Features.Student.Queries.GetStudentDetails;

public record GetStudentDetailRequest(int id) : IRequest<StudentDetailDto>;

