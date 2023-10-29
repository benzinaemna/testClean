using AutoMapper;
using MediatR;
using Test.Application.Contracts.Persistence;
using Test.Application.Exceptions;

namespace Test.Application.Features.School.commands.CreateSchool;

public class CreateSchoolCommandHandler : IRequestHandler<CreateSchoolCommand>
{
    private readonly ISchoolRepository _schoolRepository;
    private readonly IMapper _mapper;

    public CreateSchoolCommandHandler(ISchoolRepository schoolRepository, IMapper mapper)
    {
        this._schoolRepository = schoolRepository;
        this._mapper = mapper;
    }
    public async Task Handle(CreateSchoolCommand request, CancellationToken cancellationToken)

    {
        var validator = new CreateSchoolCommandValidator();
        var validationResult = await validator.ValidateAsync(request);
        if (validationResult.Errors.Any())
        {
            throw new BadRequestException("request not valid",validationResult);
        }
        var data = _mapper.Map<Domain.School>(request);
        await _schoolRepository.CreateAsync(data);
    }
}
