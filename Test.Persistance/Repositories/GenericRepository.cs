using Microsoft.EntityFrameworkCore;
using Test.Application.Contracts.Persistence;
using Test.Domain.Common;
using Test.Persistance.Context;

namespace Test.Persistance.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    protected readonly TestContext _testContext;

    public GenericRepository(TestContext testContext)
    {
        this._testContext = testContext;
    }
    public async Task CreateAsync(T entity)
    {
        await _testContext.AddAsync(entity);
        await _testContext.SaveChangesAsync();
        
    }

    public async Task DeleteAsync(T entity)
    {
         _testContext.Remove(entity);
        await _testContext.SaveChangesAsync();
    }

    public async Task<IReadOnlyList<T>> GetAsync()
    {
        return await _testContext.Set<T>().AsNoTracking().ToListAsync();
    }

    public async Task<T> GetByIdAsyn(int id)
    {
        return await _testContext.Set<T>().AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task UpdateAsync(T entity)
    {
        _testContext.Entry(entity).State = EntityState.Modified;
        await _testContext.SaveChangesAsync();
    }
}
