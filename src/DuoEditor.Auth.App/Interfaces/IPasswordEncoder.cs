namespace DuoEditor.Auth.App.Interfaces
{
  public interface IPasswordEncoder
  {
    string Encode(string password);
    bool Verify(string encoded, string password);
  }
}