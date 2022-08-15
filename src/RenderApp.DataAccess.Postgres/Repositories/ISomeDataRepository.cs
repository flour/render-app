using System.Linq.Expressions;
using RenderApp.Domain;

namespace RenderApp.DataAccess.Postgres.Repositories;

public interface ISomeDataRepository
{
    Task<(long total, List<SomeData> data)> GetData(
        int page,
        int count,
        Expression<Func<SomeData, bool>> predicate,
        CancellationToken token = default);
}