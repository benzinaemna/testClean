using AutoMapper;
using MediatR;
using Test.Application.Contracts.Persistence;

namespace Test.Application.Features.Student.Queries.GetAllStudents;

public class GetStudentsRequestHandler : IRequestHandler<GetStudentRequest, List<StudentDto>>
{
    private readonly IStudentRepository _studentRepository;
    private readonly IMapper _mapper;

    public GetStudentsRequestHandler(IStudentRepository studentRepository, IMapper mapper)
    {
        this._studentRepository = studentRepository;
        this._mapper = mapper;
    }
    public async Task<List<StudentDto>> Handle(GetStudentRequest request, CancellationToken cancellationToken)
    {
        var listStudent = await _studentRepository.GetAsync();
        var data = _mapper.Map<List<StudentDto>>(listStudent);
        return data;
    }
}


