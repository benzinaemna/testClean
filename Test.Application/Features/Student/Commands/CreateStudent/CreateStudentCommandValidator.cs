using FluentValidation;
using Test.Application.Contracts.Persistence;

namespace Test.Application.Features.Student.Commands.CreateStudent
{
    public class CreateStudentCommandValidator:AbstractValidator<CreateStudentCommand>
    {
        private readonly ISchoolRepository _schoolRepository;

        public CreateStudentCommandValidator(ISchoolRepository schoolRepository)
        {
            this._schoolRepository = schoolRepository;
            RuleFor(p => p.StudentName).NotEmpty().WithMessage("student name is empty")
                                        .MaximumLength(100).WithMessage("student name > 100");
            RuleFor(p => p.BirthDate).NotEmpty().WithMessage("birth of student is empty");
            RuleFor(p => p.SchoolID).NotEmpty().WithMessage("school id is empty")
                                    .MustAsync(SchoolExist).WithMessage("school does not exist");
           
        }
        private async Task<bool> SchoolExist(int SchoolId, CancellationToken token)
        {
            var schoolExist = await _schoolRepository.GetByIdAsyn(SchoolId);
            return schoolExist != null;
        }

    }
}
