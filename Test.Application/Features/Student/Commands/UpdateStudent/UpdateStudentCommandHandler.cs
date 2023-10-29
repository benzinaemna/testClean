using AutoMapper;
using MediatR;
using Test.Application.Contracts.Persistence;
using Test.Application.Exceptions;

namespace Test.Application.Features.Student.Commands.UpdateStudent
{
    internal class UpdateStudentCommandHandler:IRequestHandler<UpdateStudentCommand>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;
        private readonly ISchoolRepository _schoolRepository;

        public UpdateStudentCommandHandler(IStudentRepository studentRepository , IMapper mapper, ISchoolRepository schoolRepository) {
            this._studentRepository = studentRepository;
            this._mapper = mapper;
            this._schoolRepository = schoolRepository;
        }

        public async Task Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateStudentCommandValidator(_studentRepository,_schoolRepository);
            var validationResult =await validator.ValidateAsync(request);
            if (validationResult.Errors.Any())
            {
                throw new BadRequestException("request not valid", validationResult);
            }
            var student = _mapper.Map<Domain.Student>(request);
            await _studentRepository.UpdateAsync(student);
        }
    }
}
