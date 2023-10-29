using AutoMapper;
using MediatR;
using Test.Application.Contracts.Persistence;
using Test.Application.Exceptions;

namespace Test.Application.Features.Student.Commands.CreateStudent;

public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand>
{
    private readonly IStudentRepository _studentRepository;
    private readonly IMapper _mapper;
    private readonly ISchoolRepository _schoolRepository;

    public CreateStudentCommandHandler(IStudentRepository studentRepository , IMapper mapper,ISchoolRepository schoolRepository)
    {
        this._studentRepository = studentRepository;
        this._mapper = mapper;
        this._schoolRepository = schoolRepository;
    }
    public async Task Handle(CreateStudentCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateStudentCommandValidator(_schoolRepository);
        var validateResult = await validator.ValidateAsync(request);
        if (validateResult.Errors.Any())
        {
            throw new BadRequestException("request not valid", validateResult);
        }

        var student = _mapper.Map<Domain.Student>(request);
        await _studentRepository.CreateAsync(student);
    }
}
