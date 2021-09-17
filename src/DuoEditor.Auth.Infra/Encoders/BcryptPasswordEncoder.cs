using DuoEditor.Auth.App.Interfaces;

namespace DuoEditor.Auth.Infra.Encoders
{
  public class BcryptPasswordEncoder : IPasswordEncoder
  {
    public string Encode(string password)
    {
      return BCrypt.Net.BCrypt.HashPassword(password);
    }

    public bool Verify(string encoded, string password)
    {
      return BCrypt.Net.BCrypt.Verify(password, encoded);
    }
  }
}