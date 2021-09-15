using System.Net.Mail;
using DuoEditor.Auth.Domain.Enums;
using DuoEditor.Auth.Domain.Exceptions;
using DuoEditor.Auth.Domain.Interfaces;

namespace DuoEditor.Auth.Domain.Entities
{
  public class User : IValidatableEntity
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public UserStatus Status { get; set; }

    public User(string name, string email, string password)
    {
      Name = name;
      Email = email;
      Password = password;
    }

    private bool EmailIsValid()
    {
      try
      {
        var email = new MailAddress(Email);
        return true;
      }
      catch (FormatException)
      {
        return false;
      }
    }

    private bool PasswordIsValid()
    {
      return true;
    }

    public void Validate()
    {
      if (!EmailIsValid())
      {
        throw new InvalidEmailException(Email);
      }

      if (!PasswordIsValid())
      {
        throw new WeakPasswordException();
      }
    }
  }
}