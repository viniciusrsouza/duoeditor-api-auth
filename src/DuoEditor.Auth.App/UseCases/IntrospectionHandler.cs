using DuoEditor.Auth.App.Interfaces;
using DuoEditor.Auth.App.Repositories;
using DuoEditor.Auth.Domain.Entities;
using MediatR;

namespace DuoEditor.Auth.App.UseCases
{
  public class IntrospectionHandler : IRequestHandler<Introspection, (User, TokenModel)?>
  {
    private readonly IUserRepository _repository;
    private readonly ITokenEncoder _tokenEncoder;
    public IntrospectionHandler(IUserRepository repository, ITokenEncoder tokenEncoder)
    {
      _repository = repository;
      _tokenEncoder = tokenEncoder;
    }

    public async Task<(User, TokenModel)?> Handle(Introspection argument, CancellationToken cancellationToken)
    {
      var token = _tokenEncoder.Decode(argument.Token);

      if (token == null)
      {
        return null;
      };

      var user = await _repository.Get(token.Email);

      if (user == null)
      {
        return null;
      }

      return (user, token);
    }
  }
}