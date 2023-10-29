using AutoMapper;
using MediatR;
using Test.Application.Contracts.Persistence;

namespace Test.Application.Features.Student.Queries.GetStudentDetails;

public class GetStudentDetailRequestHandler : IRequestHandler<GetStudentDetailRequest, StudentDetailDto>
{
    private readonly IStudentRepository _studentRepository;
    private readonly IMapper _mapper;

    public GetStudentDetailRequestHandler(IStudentRepository studentRepository , IMapper mapper)
    {
        this._studentRepository = studentRepository;
        this._mapper = mapper;
    }
    public async Task<StudentDetailDto> Handle(GetStudentDetailRequest request, CancellationToken cancellationToken)
    {
        var student = await _studentRepository.GetByIdAsyn(request.id);
        var data = _mapper.Map<StudentDetailDto>(student);
        return data;
    }
}
