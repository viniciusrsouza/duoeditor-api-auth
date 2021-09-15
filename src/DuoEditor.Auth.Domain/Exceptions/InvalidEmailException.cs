namespace DuoEditor.Auth.Domain.Exceptions
{
  public class InvalidEmailException : BaseException
  {
    public InvalidEmailException(string email) : base($"The email {email} is not valid", "Email")
    { }
  }
}