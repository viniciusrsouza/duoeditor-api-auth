namespace DuoEditor.Auth.Domain.Exceptions
{
  public class PasswordsNotMatchingException : Exception
  {
    public PasswordsNotMatchingException() : base("The passwords do not match")
    { }
  }
}