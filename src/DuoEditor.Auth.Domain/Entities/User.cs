using DuoEditor.Auth.Domain.Enums;

namespace DuoEditor.Auth.Domain.Entities
{
  public class User
  {
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Name => $"{FirstName} {LastName}";
    public string Email { get; set; }
    public string Password { get; set; }
    public UserStatus Status { get; set; }
    public string? ProfileImage { get; set; }

    public User(string firstName, string lastName, string email, string password)
    {
      FirstName = firstName;
      LastName = lastName;
      Email = email;
      Password = password;
    }
  }
}