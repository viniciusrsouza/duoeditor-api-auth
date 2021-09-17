using DuoEditor.Auth.Domain.Enums;

namespace DuoEditor.Auth.Api.Presenters
{
  public class UserPresenter
  {
    public string Name { get; set; }
    public string? ProfileImage { get; set; }
    public UserPresenter(string name, string? profileImage)
    {
      Name = name;
      ProfileImage = profileImage;
    }
  }
}