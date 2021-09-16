using System.ComponentModel.DataAnnotations;
using DuoEditor.Auth.Domain.Rules;

namespace DuoEditor.Auth.Domain.Validators
{
  [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
  public class HasSymbol : ValidationAttribute
  {
    public HasSymbol() : base("The {0} field must contain at least one symbol")
    {
    }
    public override bool IsValid(object? value)
    {
      string? str = value as string;

      if (!string.IsNullOrEmpty(str))
      {
        return StringRules.HasSymbol(str);
      }
      return false;
    }
  }
}