using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using RenderApp.Domain;

namespace RenderApp.DataAccess.Postgres.Repositories.Internals;

internal class SomeDataRepository : ISomeDataRepository
{
    private readonly AppDbContext _context;

    public SomeDataRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<(long total, List<SomeData> data)> GetData(
        int page,
        int count,
        Expression<Func<SomeData, bool>> predicate,
        CancellationToken token = default)
    {
        var query = _context.SomeData.AsNoTracking().Where(predicate);
        var total = await query.LongCountAsync(cancellationToken: token);
        var data = await query.Skip(((page <= 0 ? 1 : page) - 1) * count).Take(count).ToListAsync(token);
        
        return (total, data);
    }
}