using RenderApp.DataAccess.Postgres.Repositories;
using RenderApp.DataAccess.Postgres.Repositories.Internals;

namespace RenderApp.DataAccess.Postgres;

internal class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    private readonly Lazy<SomeDataRepository> _someDataRepo;
    
    public ISomeDataRepository SomeData => _someDataRepo.Value;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
        _someDataRepo = new Lazy<SomeDataRepository>(() => new(_context));
    }

    public async Task<T> AddAndSave<T>(T entity, CancellationToken token = default) where T : class
    {
        _context.Set<T>().Add(entity);
        await _context.SaveChangesAsync(token);

        return entity;
    }

    public async Task<T> UpdateAndSave<T>(T entity, CancellationToken token = default) where T : class
    {
        _context.Set<T>().Update(entity);
        await _context.SaveChangesAsync(token);

        return entity;
    }

    public async Task<bool> Save(CancellationToken token = default)
    {
        return await _context.SaveChangesAsync(token) > 0;
    }
}