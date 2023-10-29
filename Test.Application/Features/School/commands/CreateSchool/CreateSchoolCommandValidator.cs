using FluentValidation;

namespace Test.Application.Features.School.commands.CreateSchool;

public class CreateSchoolCommandValidator:AbstractValidator<CreateSchoolCommand>
{
    public CreateSchoolCommandValidator()
    {
        RuleFor(p => p.SchoolAdress).NotEmpty().WithMessage("school adress is empty")
                                    .MaximumLength(100).WithMessage("school adress > 100");
        RuleFor(p => p.SchoolName).NotEmpty().WithMessage("school name is empty")
                                  .MaximumLength(100).WithMessage("School name > 100");
        
    }
}
