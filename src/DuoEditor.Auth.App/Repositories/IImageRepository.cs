using DuoEditor.Auth.Domain.Entities;

namespace DuoEditor.Auth.App.Repositories
{
  public interface IImageRepository
  {
    Task<string?> GetImage(User user);
  }
}