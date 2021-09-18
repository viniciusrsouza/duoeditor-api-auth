using DuoEditor.Auth.Domain.Entities;

namespace DuoEditor.Auth.App.Repositories
{
  public interface ITokenRepository
  {
    Task<RefreshToken?> Get(string token);
    Task<RefreshToken?> Create(RefreshToken token);
    Task<RefreshToken?> Delete(string token);
    Task<RefreshToken?> Update(RefreshToken token);

  }
}