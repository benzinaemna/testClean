using MediatR;
using Test.Application.Contracts.Persistence;
using Test.Application.Exceptions;

namespace Test.Application.Features.Student.Commands.DeleteStudent;

public class DeleteStudentCommandHandler : IRequestHandler<DeleteStudentCommand>
{
    private readonly IStudentRepository _studentRepository;

    public DeleteStudentCommandHandler(IStudentRepository studentRepository)
    {
        this._studentRepository = studentRepository;
    }
    public async Task Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
    {
        var student =await _studentRepository.GetByIdAsyn(request.id);
        if (student == null)
        {
            throw new NotFoundException(nameof(Domain.Student), request.id);
        }
        await _studentRepository.DeleteAsync(student);
    }
}
