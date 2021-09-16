using DuoEditor.Auth.App.Interfaces;

namespace DuoEditor.Auth.Infra.Encryptors
{
  public class BcryptPasswordEncryptor : IPasswordEncryptor
  {
    public string Encrypt(string password)
    {
      return BCrypt.Net.BCrypt.HashPassword(password);
    }

    public bool Verify(string encoded, string password)
    {
      return BCrypt.Net.BCrypt.Verify(password, encoded);
    }
  }
}