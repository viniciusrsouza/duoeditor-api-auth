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