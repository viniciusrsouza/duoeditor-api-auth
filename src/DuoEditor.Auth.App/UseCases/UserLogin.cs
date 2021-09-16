using System.ComponentModel.DataAnnotations;
using DuoEditor.Auth.Domain.Entities;
using MediatR;

namespace DuoEditor.Auth.App.UseCases
{
  public class UserLogin : IRequest<Token>
  {
    [Required]
    public string Email { get; set; } = "";

    [Required]
    public string Password { get; set; } = "";
  }
}