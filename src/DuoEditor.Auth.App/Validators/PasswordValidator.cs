using DuoEditor.Auth.Domain.Exceptions;
using DuoEditor.Auth.Domain.Rules;

namespace DuoEditor.Auth.App.Validators
{
  public class PasswordValidator
  {
    const int MIN_LENGTH = 6;
    const int MAX_LENGTH = 16;
    const bool REQUIRE_LETTER = true;
    const bool REQUIRE_LOWERCASE = true;
    const bool REQUIRE_UPPERCASE = true;
    const bool REQUIRE_DIGIT = true;
    const bool REQUIRE_SYMBOL = true;

    public static void Validate(string password)
    {
      if (password.Length < MIN_LENGTH) throw new WeakPasswordException();
      if (password.Length > MAX_LENGTH) throw new PasswordExceedingLengthException(MAX_LENGTH);
      if (REQUIRE_LETTER && !PasswordRules.HasLetter(password)) throw new WeakPasswordException();
      if (REQUIRE_LOWERCASE && !PasswordRules.HasLowercase(password)) throw new WeakPasswordException();
      if (REQUIRE_UPPERCASE && !PasswordRules.HasUppercase(password)) throw new WeakPasswordException();
      if (REQUIRE_DIGIT && !PasswordRules.HasDigit(password)) throw new WeakPasswordException();
      if (REQUIRE_SYMBOL && !PasswordRules.HasSymbol(password)) throw new WeakPasswordException();
    }
  }
}