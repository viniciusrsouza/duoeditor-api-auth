using DuoEditor.Auth.App.Repositories;
using DuoEditor.Auth.Domain.Entities;
using DuoEditor.Auth.Infra.Persistence;

namespace DuoEditor.Auth.Infra.Repositories
{
  public class UserRepository : IUserRepository
  {
    public UserRepository(ApiDbContext context)
    {
      _context = context;
    }

    public ApiDbContext _context { get; set; }

    public async Task<User?> Create(User user)
    {
      var entry = _context.Users.Add(user);
      await _context.SaveChangesAsync();
      return entry.Entity;
    }

    public async Task<User?> Delete(string email)
    {
      var user = _context.Users.First(x => x.Email == email);
      if (user == null)
      {
        return null;
      }

      var entry = _context.Users.Remove(user);
      await _context.SaveChangesAsync();
      return entry.Entity;
    }

    public async Task<User?> Delete(int id)
    {
      var user = _context.Users.Find(id);
      if (user == null)
      {
        return null;
      }

      var entry = _context.Users.Remove(user);
      await _context.SaveChangesAsync();
      return entry.Entity;
    }

    public User? Get(string email)
    {
      return _context.Users.FirstOrDefault(x => x.Email == email);
    }

    public User? Get(int id)
    {
      return _context.Users.Find(id);
    }

    public async Task<User?> Update(User user)
    {
      var entry = _context.Users.Update(user);
      await _context.SaveChangesAsync();
      return entry.Entity;
    }
  }
}