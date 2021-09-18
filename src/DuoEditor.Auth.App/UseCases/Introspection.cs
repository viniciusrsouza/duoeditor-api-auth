using DuoEditor.Auth.Domain.Entities;
using MediatR;

namespace DuoEditor.Auth.App.UseCases
{
  public class Introspection : IRequest<(User, TokenModel)?>
  {
    public string Token { get; set; }

    public Introspection(string token)
    {
      Token = token;
    }
  }
}