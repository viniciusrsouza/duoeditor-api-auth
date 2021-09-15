namespace DuoEditor.Auth.Domain.Exceptions
{
  public class WeakPasswordException : BaseException
  {
    public WeakPasswordException() : base("The password is too weak", "Password") { }
  }
}