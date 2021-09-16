using System.ComponentModel.DataAnnotations;
using DuoEditor.Auth.Domain.Rules;

namespace DuoEditor.Auth.Domain.Validators
{
  [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
  public class IsValidEmail : ValidationAttribute
  {
    public IsValidEmail() : base("The {0} field must be a valid email")
    {
    }
    public override bool IsValid(object? value)
    {
      string? str = value as string;

      if (!string.IsNullOrEmpty(str))
      {
        return StringRules.IsValidEmail(str);
      }
      return false;
    }
  }
}