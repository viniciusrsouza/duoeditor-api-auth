using System.ComponentModel.DataAnnotations;
using DuoEditor.Auth.Domain.Validators;
using DuoEditor.Auth.Domain.Entities;
using MediatR;

namespace DuoEditor.Auth.App.UseCases
{
  public class UserRegister : IRequest<User>
  {
    [Required]
    public string FirstName { get; set; } = "";

    [Required]
    public string LastName { get; set; } = "";

    [Required]
    [IsValidEmail]
    public string Email { get; set; } = "";

    [Required]
    [MinLength(6)]
    [MaxLength(16)]
    [HasUppercase]
    [HasLowercase]
    [HasDigit]
    public string Password { get; set; } = "";

    [Required]
    [Compare(nameof(Password), ErrorMessage = "The passwords do not match")]
    public string ConfirmPassword { get; set; } = "";
  }
}