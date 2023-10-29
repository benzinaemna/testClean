using AutoMapper;
using MediatR;
using Test.Application.Contracts.Persistence;

namespace Test.Application.Features.School.Queries.GetAllSchools;

public class GetSchoolsRequestHandler : IRequestHandler<GetSchoolsRequest, List<SchoolDto>>
{
    private readonly ISchoolRepository _schoolRepository;
    private readonly IMapper _mapper;

    public GetSchoolsRequestHandler(ISchoolRepository schoolRepository , IMapper mapper)
    {
        this._schoolRepository = schoolRepository;
        this._mapper = mapper;
    }
    public async Task<List<SchoolDto>> Handle(GetSchoolsRequest request, CancellationToken cancellationToken )
    {
        var listSchools = await _schoolRepository.GetAsync();
        var data = _mapper.Map<List<SchoolDto>>(listSchools);
        return data;
    }
}
