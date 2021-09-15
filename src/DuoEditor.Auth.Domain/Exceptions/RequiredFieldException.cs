namespace DuoEditor.Auth.Domain.Exceptions
{
  public class RequiredFieldException : BaseException
  {
    public RequiredFieldException(string field) : base("This field is Required", field)
    {
    }
  }
}