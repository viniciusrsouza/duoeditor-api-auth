using DuoEditor.Auth.Domain.Enums;

namespace DuoEditor.Auth.Domain.Entities
{
  public class TokenModel
  {
    public int Id { get; set; } = 0;
    public long Exp { get; set; } = 0;
    public TokenType Type { get; set; } = TokenType.Refresh;
    public string Email { get; set; } = "";
  }
}