namespace DuoEditor.Auth.Domain.Entities
{
  public class Token
  {
    public string Access { get; set; } = "";
    public string Refresh { get; set; } = "";
  }
}