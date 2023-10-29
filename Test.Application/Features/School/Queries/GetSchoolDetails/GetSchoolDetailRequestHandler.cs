using AutoMapper;
using MediatR;
using Test.Application.Contracts.Persistence;

namespace Test.Application.Features.School.Queries.GetSchoolDetails;

public class GetSchoolDetailRequestHandler:IRequestHandler<GetSchoolDetailRequest,SchoolDetailDto> 
{
    private readonly ISchoolRepository _schoolRepository;
    private readonly IMapper _mapper;

    public GetSchoolDetailRequestHandler(ISchoolRepository schoolRepository, IMapper mapper )
    {
        this._schoolRepository = schoolRepository;
        this._mapper = mapper;
    }

    public async Task<SchoolDetailDto> Handle(GetSchoolDetailRequest request, CancellationToken cancellationToken)
    {
        var school = await _schoolRepository.GetByIdAsyn(request.id);
        var data = _mapper.Map<SchoolDetailDto>(school);
        return data;

    }
}

