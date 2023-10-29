using Test.Domain;

namespace Test.Application.Contracts.Persistence;

public interface IStudentRepository :IGenericRepository<Student>
{
    Task <bool> StudentExists(int Id);
}
