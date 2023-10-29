using MediatR;
using Test.Application.Contracts.Persistence;
using Test.Application.Exceptions;

namespace Test.Application.Features.School.commands.DeleteSchool;

public class DeleteSchoolCommandHandler : IRequestHandler<DeleteSchoolCommand>
{
    private readonly ISchoolRepository _schoolRepository;

    public DeleteSchoolCommandHandler(ISchoolRepository schoolRepository)
    {
        this._schoolRepository = schoolRepository;
    }
    public async Task Handle(DeleteSchoolCommand request, CancellationToken cancellationToken)
    {
        var school = await _schoolRepository.GetByIdAsyn(request.id);
        if (school == null)
        {
            throw new NotFoundException(nameof(Domain.School), request.id);
        }
        await _schoolRepository.DeleteAsync(school);
    }
}
