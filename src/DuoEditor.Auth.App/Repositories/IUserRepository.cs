using DuoEditor.Auth.Domain.Entities;

namespace DuoEditor.Auth.App.Repositories
{
  public interface IUserRepository
  {
    User? Get(string email);
    User? Get(int id);
    Task<User?> Create(User user);
    Task<User?> Delete(string email);
    Task<User?> Delete(int id);
    Task<User?> Update(User user);
  }
}