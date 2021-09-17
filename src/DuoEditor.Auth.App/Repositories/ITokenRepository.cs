namespace DuoEditor.Auth.App.Repositories
{
  public interface ITokenRepository
  {
    Task<bool> Has(string token);
    Task<bool> Replace(string token, string newToken);
    Task<bool> Remove(string token);
    Task<bool> Add(string token);

  }
}