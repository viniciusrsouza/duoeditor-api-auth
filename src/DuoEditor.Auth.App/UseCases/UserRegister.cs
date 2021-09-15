using DuoEditor.Auth.Domain.Entities;
using MediatR;

namespace DuoEditor.Auth.App.UseCases
{
  public class UserRegister : IRequest<User>
  {
    public string FirstName;
    public string LastName;
    public string Email;
    public string Password;
    public string ConfirmPassword;

    public UserRegister(string firstName, string lastName, string email, string password, string confirmPassword)
    {
      FirstName = firstName;
      LastName = lastName;
      Email = email;
      Password = password;
      ConfirmPassword = confirmPassword;
    }
  }
}