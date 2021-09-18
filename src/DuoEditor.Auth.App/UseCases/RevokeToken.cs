using DuoEditor.Auth.Domain.Entities;
using MediatR;

namespace DuoEditor.Auth.App.UseCases
{
  public class RevokeToken : IRequest
  {
    public string Token { get; set; }

    public RevokeToken(string token)
    {
      Token = token;
    }
  }
}