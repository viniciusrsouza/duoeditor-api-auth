namespace DuoEditor.Auth.Domain.Exceptions
{
  public class ExistingUserException : Exception
  {
    public ExistingUserException(string email) : base("There is already a user with email {email}.")
    {

    }
  }
}