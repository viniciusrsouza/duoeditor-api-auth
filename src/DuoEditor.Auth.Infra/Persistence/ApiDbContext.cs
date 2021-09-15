using DuoEditor.Auth.App.Interfaces;
using DuoEditor.Auth.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DuoEditor.Auth.Infra.Persistence
{
  public class ApiDbContext : DbContext, IDbContext
  {
    public DbSet<User> Users { get; set; }

    public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
    {

    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
      var result = await base.SaveChangesAsync(cancellationToken);
      return result;
    }
  }
}