namespace DuoEditor.Auth.Domain.Exceptions
{
  public class WeakPasswordException : Exception
  {
    public WeakPasswordException() : base("The password is too weak") { }
  }
}