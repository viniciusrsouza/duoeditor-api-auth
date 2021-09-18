using System.ComponentModel.DataAnnotations;

namespace DuoEditor.Auth.Domain.Entities
{
  public class RefreshToken : Entity
  {
    public string Value { get; set; } = null!;
    public User User { get; set; } = null!;
    public DateTimeOffset Expiration { get; set; }

    public RefreshToken(string value, User user, DateTimeOffset expiration)
    {
      Value = value;
      User = user;
      Expiration = expiration;
    }

    private RefreshToken()
    { }
  }
}