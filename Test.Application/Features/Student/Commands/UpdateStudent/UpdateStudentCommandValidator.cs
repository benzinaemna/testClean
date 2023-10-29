using FluentValidation;
using Test.Application.Contracts.Persistence;

namespace Test.Application.Features.Student.Commands.UpdateStudent
{
    public class UpdateStudentCommandValidator:AbstractValidator<UpdateStudentCommand>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly ISchoolRepository _schoolRepository;

        public UpdateStudentCommandValidator(IStudentRepository studentRepository , ISchoolRepository schoolRepository)
        {
            this._studentRepository = studentRepository;
            this._schoolRepository = schoolRepository;
            RuleFor(p => p.StudentName).NotEmpty().WithMessage("student name is empty")
                                        .MaximumLength(100).WithMessage("student name > 100");
            RuleFor(p => p.BirthDate).NotEmpty().WithMessage("birth of student is empty");
            RuleFor(p => p.SchoolID).NotEmpty().WithMessage("school id is empty")
                                    .MustAsync(SchoolExist).WithMessage("school does not exist");
            RuleFor(p => p.Id).NotNull().WithMessage("id is null")
                              .MustAsync(StudentExist).WithMessage("id does not exist");
            
        }

        private async Task<bool> SchoolExist(int SchoolId, CancellationToken token)
        {
            var schoolExist = await _schoolRepository.GetByIdAsyn(SchoolId);
            return schoolExist != null;
        }

        private async Task<bool> StudentExist(int Id, CancellationToken token)
        {
            var studentExist = await _studentRepository.GetByIdAsyn(Id);
            return studentExist != null;
        }
    }
}
