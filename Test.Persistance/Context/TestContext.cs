using Microsoft.EntityFrameworkCore;
using Test.Domain;
using Test.Domain.Common;

namespace Test.Persistance.Context;

public class TestContext:DbContext
{
    public TestContext()
    {
        
    }
    public TestContext(DbContextOptions<TestContext> dbContextOptions):base(dbContextOptions)
    {
        
    }
    public DbSet<School> schools { get; set; }
    public DbSet<Student> students { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TestContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in base.ChangeTracker.Entries<BaseEntity>().Where(h=>h.State==EntityState.Added || h.State==EntityState.Modified))
        {
            entry.Entity.DateModified= DateTime.UtcNow;
            if (entry.State == EntityState.Added)
            {
                entry.Entity.DateCreated= DateTime.UtcNow;
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }
}
