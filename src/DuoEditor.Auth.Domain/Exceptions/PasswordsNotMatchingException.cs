namespace DuoEditor.Auth.Domain.Exceptions
{
  public class PasswordsNotMatchingException : BaseException
  {
    public PasswordsNotMatchingException() : base("The passwords do not match", "Password", "ConfirmPassword")
    { }
  }
}