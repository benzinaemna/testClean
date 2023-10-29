using MediatR;

namespace Test.Application.Features.School.Queries.GetAllSchools;

public record GetSchoolsRequest:IRequest<List<SchoolDto>>;