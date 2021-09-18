using System.Text.Json;
using DuoEditor.Auth.App.Interfaces;
using DuoEditor.Auth.App.Repositories;
using DuoEditor.Auth.Domain.Entities;
using MediatR;

namespace DuoEditor.Auth.App.UseCases
{
  public class TokenRefreshHandler : IRequestHandler<TokenRefresh, Token?>
  {
    private readonly IUserRepository _repository;
    private readonly ITokenEncoder _tokenEncoder;
    private readonly ITokenRepository _tokenRepository;
    public TokenRefreshHandler(IUserRepository repository, ITokenRepository tokenRepository, ITokenEncoder tokenEncoder)
    {
      _repository = repository;
      _tokenRepository = tokenRepository;
      _tokenEncoder = tokenEncoder;
    }

    public async Task<Token?> Handle(TokenRefresh argument, CancellationToken cancellationToken)
    {
      var _token = await _tokenRepository.Delete(argument.Token);

      if (_token == null)
      {
        return null;
      };

      Console.WriteLine(JsonSerializer.Serialize(_token));

      var token = _tokenEncoder.Encode(_token.User);
      var refreshToken = new RefreshToken(token.Refresh, _token.User, DateTimeOffset.Now.AddSeconds(30));
      await _tokenRepository.Create(refreshToken);
      return token;
    }
  }
}