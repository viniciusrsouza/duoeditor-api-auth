using System.Net.Mail;
using DuoEditor.Auth.Domain.Enums;
using DuoEditor.Auth.Domain.Exceptions;
using DuoEditor.Auth.Domain.Interfaces;

namespace DuoEditor.Auth.Domain.Entities
{
  public class User : IValidatableEntity
  {
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Name => $"{FirstName} {LastName}";
    public string Email { get; set; }
    public string Password { get; set; }
    public UserStatus Status { get; set; }

    public User(string firstName, string lastName, string email, string password)
    {
      FirstName = firstName;
      LastName = lastName;
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

    public void Validate()
    {
      if (!EmailIsValid())
      {
        throw new InvalidEmailException(Email);
      }
      if (FirstName.Length == 0)
      {
        throw new RequiredFieldException("FirstName");
      }
      if (LastName.Length == 0)
      {
        throw new RequiredFieldException("LastName");
      }
    }
  }
}