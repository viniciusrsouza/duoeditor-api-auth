using DuoEditor.Auth.Domain.Entities;

namespace DuoEditor.Auth.App.Repositories
{
  public interface IUserRepository
  {
    User Get(string email);
    User Get(int id);
    User Create(User user);
    User Delete(string email);
    User Delete(int id);
    User Update(User user);
  }
}