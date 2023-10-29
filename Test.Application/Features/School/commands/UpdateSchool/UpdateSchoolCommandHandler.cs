using AutoMapper;
using MediatR;
using Test.Application.Contracts.Persistence;
using Test.Application.Exceptions;

namespace Test.Application.Features.School.commands.UpdateSchool;

internal class UpdateSchoolCommandHandler : IRequestHandler<UpdateSchoolCommand>
{
    private readonly ISchoolRepository _schoolRepository;
    private readonly IMapper _mapper;

    public UpdateSchoolCommandHandler(ISchoolRepository schoolRepository, IMapper mapper)
    {
        this._schoolRepository = schoolRepository;
        this._mapper = mapper;
    }

    public async Task Handle(UpdateSchoolCommand request, CancellationToken cancellationToken)
    {
        var validator = new UpdateSchoolCommandValidator(_schoolRepository);
        var validationResult = await validator.ValidateAsync(request);
        if (validationResult.Errors.Any())
        {
            throw new BadRequestException("request not valid", validationResult);
        }
        var data = _mapper.Map<Domain.School>(request);
        await _schoolRepository.UpdateAsync(data);
    }
}
