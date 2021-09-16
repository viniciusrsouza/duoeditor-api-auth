using DuoEditor.Auth.Domain.Entities;
using DuoEditor.Auth.Domain.Enums;

namespace DuoEditor.Auth.App.Interfaces
{
  public interface ITokenEncryptor
  {
    Token Encrypt(User user);
    Dictionary<string, string> Decrypt(string token);
  }
}