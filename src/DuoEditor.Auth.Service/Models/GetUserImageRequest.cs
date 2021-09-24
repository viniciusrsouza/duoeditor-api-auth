using DuoEditor.Auth.Domain.Entities;

namespace DuoEditor.Auth.Service.Models
{
  public class GetUserImageRequest
  {
    public User User { get; set; } = null!;
  }
}