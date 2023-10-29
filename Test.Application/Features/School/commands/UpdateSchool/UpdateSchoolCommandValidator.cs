using FluentValidation;
using Test.Application.Contracts.Persistence;

namespace Test.Application.Features.School.commands.UpdateSchool;

public class UpdateSchoolCommandValidator :AbstractValidator<UpdateSchoolCommand>
{
    private readonly ISchoolRepository _schoolRepository;

    public UpdateSchoolCommandValidator(ISchoolRepository schoolRepository)
    {
        RuleFor(p => p.SchoolAdress).MaximumLength(100).WithMessage("length > 100")
                                  .NotEmpty().WithMessage("school is empty");
        RuleFor(p => p.SchoolName).NotEmpty().WithMessage("school name is empty")
                                  .MaximumLength(100).WithMessage("Length > 100");

        RuleFor(p => p.Id).NotNull().WithMessage("the id is null")
                          .MustAsync(SchoolMustExist).WithMessage("id does not exist");
        this._schoolRepository = schoolRepository;
    }

    private async Task<bool> SchoolMustExist(int Id, CancellationToken token)
    {
        var schoolExist = await _schoolRepository.GetByIdAsyn(Id);
        return schoolExist != null;
    }
}
