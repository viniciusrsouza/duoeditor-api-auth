namespace DuoEditor.Auth.Domain.Exceptions
{
  public class ExistingUserException : BaseException
  {
    public ExistingUserException(string email) : base($"There is already a user with email {email}.", "Email")
    {

    }
  }
}