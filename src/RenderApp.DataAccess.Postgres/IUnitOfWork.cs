using RenderApp.DataAccess.Postgres.Repositories;

namespace RenderApp.DataAccess.Postgres;

public interface IUnitOfWork
{
    ISomeDataRepository SomeData { get; }

    Task<T> AddAndSave<T>(T entity, CancellationToken token = default) where T : class;
    Task<T> UpdateAndSave<T>(T entity, CancellationToken token = default) where T : class;
    Task<bool> Save(CancellationToken token = default);
}