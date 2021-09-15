namespace DuoEditor.Auth.Domain.Exceptions
{
  public class BaseException : Exception
  {
    public BaseException(string message, params string[] fields) : base(message)
    {
      Fields = fields;
    }
    string[] Fields { get; set; }
  }
}