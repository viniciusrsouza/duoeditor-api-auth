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
      User user;
      try
      {
        user = _context.Users.First(x => x.Email == email);
      }
      catch (Exception)
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

    public async Task<User?> Get(string email)
    {
      try
      {
        return await Task.Run(() => _context.Users.First(x => x.Email == email));
      }
      catch (Exception)
      {
        return null;
      }
    }

    public async Task<User?> Get(int id)
    {
      return await Task.Run(() => _context.Users.Find(id));
    }

    public async Task<User?> Update(User user)
    {
      var entry = _context.Users.Update(user);
      await _context.SaveChangesAsync();
      return entry.Entity;
    }
  }
}