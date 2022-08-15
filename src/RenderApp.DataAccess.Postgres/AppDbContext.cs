using Microsoft.EntityFrameworkCore;
using RenderApp.Domain;

namespace RenderApp.DataAccess.Postgres;

public class AppDbContext : DbContext
{
    private DbSet<SomeData> SomeData { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
}