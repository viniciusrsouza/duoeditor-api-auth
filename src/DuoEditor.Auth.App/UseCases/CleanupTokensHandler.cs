using DuoEditor.Auth.App.Repositories;
using DuoEditor.Auth.Domain.Entities;
using MediatR;

namespace DuoEditor.Auth.App.UseCases
{
  public class CleanupTokensHandler : IRequestHandler<CleanupTokens>
  {
    private ITokenRepository _repository;
    public CleanupTokensHandler(ITokenRepository repository)
    {
      _repository = repository;
    }

    public async Task<Unit> Handle(CleanupTokens argument, CancellationToken cancellationToken)
    {
      await _repository.DeleteExpired();

      return Unit.Value;
    }
  }
}