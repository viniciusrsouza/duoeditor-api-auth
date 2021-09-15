using DuoEditor.Auth.App.Interfaces;
using DuoEditor.Auth.App.Repositories;
using DuoEditor.Auth.Domain.Entities;

namespace DuoEditor.Auth.Infra.Repositories
{
  public class UserRepository : IUserRepository
  {
    public UserRepository(IDbContext context)
    {
      _context = context;
    }

    public IDbContext _context { get; set; }

    public User Create(User user)
    {
      throw new NotImplementedException();
    }

    public User Delete(string email)
    {
      throw new NotImplementedException();
    }

    public User Delete(int id)
    {
      throw new NotImplementedException();
    }

    public User Get(string email)
    {
      throw new NotImplementedException();
    }

    public User Get(int id)
    {
      throw new NotImplementedException();
    }

    public User Update(User user)
    {
      throw new NotImplementedException();
    }
  }
}