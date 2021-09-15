namespace DuoEditor.Auth.App.Interfaces
{
  public interface IPasswordEncryptor
  {
    string Encrypt(string password);
    bool Verify(string encoded, string password);
  }
}