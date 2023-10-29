using Test.Application.Contracts.Persistence;
using Test.Domain;
using Test.Persistance.Context;

namespace Test.Persistance.Repositories;

public class StudentRepository : GenericRepository<Student>, IStudentRepository
{
    public StudentRepository(TestContext testContext) : base(testContext)
    {
    }

    public async Task<bool> StudentExists(int Id)
    {
        var studentExist = await GetByIdAsyn(Id);
        return studentExist != null;
    }
}
