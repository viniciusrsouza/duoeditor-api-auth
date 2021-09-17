using DuoEditor.Auth.Domain.Entities;
using DuoEditor.Auth.Domain.Enums;

namespace DuoEditor.Auth.App.Interfaces
{
  public interface ITokenEncoder
  {
    Token Encode(User user);
    TokenModel? Decode(string token);
  }
}