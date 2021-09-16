using System.ComponentModel.DataAnnotations;
using DuoEditor.Auth.Domain.Rules;

namespace DuoEditor.Auth.Domain.Validators
{
  [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
  public class HasUppercase : ValidationAttribute
  {
    public HasUppercase() : base("The {0} field must contain at least one upper case letter")
    {
    }
    public override bool IsValid(object? value)
    {
      string? str = value as string;

      if (!string.IsNullOrEmpty(str))
      {
        return StringRules.HasUppercase(str);
      }
      return false;
    }
  }
}