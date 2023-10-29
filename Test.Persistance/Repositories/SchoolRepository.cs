using Test.Application.Contracts.Persistence;
using Test.Domain;
using Test.Persistance.Context;

namespace Test.Persistance.Repositories;

public class SchoolRepository : GenericRepository<School>, ISchoolRepository
{
    public SchoolRepository(TestContext testContext) : base(testContext)
    {
    }

    public async Task AddStudents(List<Student> students)
    {
       await _testContext.AddRangeAsync(students);
      await  _testContext.SaveChangesAsync();
    }
}
