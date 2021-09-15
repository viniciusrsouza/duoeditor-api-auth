namespace DuoEditor.Auth.Domain.Exceptions
{
  public class PasswordExceedingLengthException : BaseException
  {
    public PasswordExceedingLengthException(int length) : base($"The password exceeds the max length of {length}", "Password") { }
  }
}