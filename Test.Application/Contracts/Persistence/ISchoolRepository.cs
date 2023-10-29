using Test.Domain;

namespace Test.Application.Contracts.Persistence;

public interface ISchoolRepository :IGenericRepository<School>
{
    Task AddStudents(List<Student> students);
}
