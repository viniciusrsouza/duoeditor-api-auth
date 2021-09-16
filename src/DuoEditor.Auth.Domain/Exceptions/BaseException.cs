using System.Collections.Generic;

namespace DuoEditor.Auth.Domain.Exceptions
{
  public class BaseException : Exception
  {
    public BaseException(string message, string field) : base(message)
    {
      Field = field;
    }
    public string Field { get; set; }
    public Dictionary<string, string[]> errors => new Dictionary<string, string[]>
    {
      [Field] = new string[] { Message }
    };
  }
}