using System.Text.RegularExpressions;

namespace DuoEditor.Auth.Domain.Rules
{
  public class PasswordRules
  {
    public static bool HasLetter(string password) => new Regex(@"\([A-Z]|[a-z]){1,}\").IsMatch(password);
    public static bool HasUppercase(string password) => new Regex(@"\[A-Z]{1,}\").IsMatch(password);
    public static bool HasLowercase(string password) => new Regex(@"\[a-z]{1,}\").IsMatch(password);
    public static bool HasDigit(string password) => new Regex(@"\[1-9]{1,}\").IsMatch(password);
    public static bool HasSymbol(string password) => new Regex(@"\[ !@#$%&*-_=+]{1,}\").IsMatch(password);
  }
}