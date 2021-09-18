using DuoEditor.Auth.Domain.Entities;
using MediatR;

namespace DuoEditor.Auth.App.UseCases
{
  public class TokenRefresh : IRequest<Token>
  {
    public string Token { get; set; }

    public TokenRefresh(string token)
    {
      Token = token;
    }
  }
}