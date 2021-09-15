using DuoEditor.Auth.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DuoEditor.Auth.App.Interfaces
{
  public interface IDbContext
  {
    DbSet<User> Users { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
  }
}