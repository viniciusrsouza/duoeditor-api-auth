using DuoEditor.Auth.Domain.Entities;
using MediatR;

namespace DuoEditor.Auth.App.UseCases
{
  public class UserRegister : IRequest<User>
  {
    public string Name;
    public string Email;
    public string Password;
    public string ConfirmPassword;

    public UserRegister(string name, string email, string password, string confirmPassword)
    {
      Name = name;
      Email = email;
      Password = password;
      ConfirmPassword = confirmPassword;
    }
  }
}