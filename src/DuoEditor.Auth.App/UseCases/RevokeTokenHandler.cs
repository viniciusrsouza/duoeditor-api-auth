using System.Text.Json;
using DuoEditor.Auth.App.Interfaces;
using DuoEditor.Auth.App.Repositories;
using DuoEditor.Auth.Domain.Entities;
using MediatR;

namespace DuoEditor.Auth.App.UseCases
{
  public class RevokeTokenHandler : IRequestHandler<RevokeToken>
  {
    private readonly ITokenRepository _repository;
    private readonly ITokenEncoder _tokenEncoder;
    public RevokeTokenHandler(ITokenRepository repository, ITokenEncoder tokenEncoder)
    {
      _repository = repository;
      _tokenEncoder = tokenEncoder;
    }

    public async Task<Unit> Handle(RevokeToken argument, CancellationToken cancellationToken)
    {
      await _repository.Delete(argument.Token);
      return Unit.Value;
    }
  }
}