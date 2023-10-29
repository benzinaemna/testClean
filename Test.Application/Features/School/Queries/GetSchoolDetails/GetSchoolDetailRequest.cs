using MediatR;

namespace Test.Application.Features.School.Queries.GetSchoolDetails;

public record GetSchoolDetailRequest(int id) : IRequest<SchoolDetailDto>;