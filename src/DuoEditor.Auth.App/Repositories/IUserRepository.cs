using DuoEditor.Auth.App.Interfaces;
using DuoEditor.Auth.Domain.Entities;

namespace DuoEditor.Auth.App.Repositories
{
  public interface IUserRepository
  {
    IDbContext _context { get; set; }
    User Get(string email);
    User Get(int id);
    User Create(User user);
    User Delete(string email);
    User Delete(int id);
    User Update(User user);
  }
}