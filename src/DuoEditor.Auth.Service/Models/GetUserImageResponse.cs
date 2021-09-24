namespace DuoEditor.Auth.Service.Models
{
  public class GetUserImageResponse
  {
    public int UserId { get; set; }
    public string FileName { get; set; } = null!;
  }
}