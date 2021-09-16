using System.Net.Mail;
using System.Text.RegularExpressions;

namespace DuoEditor.Auth.Domain.Rules
{
  public class StringRules
  {
    public static bool HasLetter(string str) => new Regex(@"([A-Z]|[a-z]){1,}").IsMatch(str);
    public static bool HasUppercase(string str) => new Regex(@"[A-Z]{1,}").IsMatch(str);
    public static bool HasLowercase(string str) => new Regex(@"[a-z]{1,}").IsMatch(str);
    public static bool HasDigit(string str) => new Regex(@"[1-9]{1,}").IsMatch(str);
    public static bool HasSymbol(string str) => new Regex(@"[ !@#$%&*-_=+]{1,}").IsMatch(str);

    public static bool IsValidEmail(string str)
    {
      try
      {
        new MailAddress(str);
        return true;
      }
      catch (FormatException)
      {
        return false;
      }
    }
  }
}