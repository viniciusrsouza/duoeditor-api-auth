using DuoEditor.Auth.App.Interfaces;
using DuoEditor.Auth.App.Repositories;
using DuoEditor.Auth.Domain.Entities;
using MediatR;

namespace DuoEditor.Auth.App.UseCases
{
  public class UserLoginHandler : IRequestHandler<UserLogin, Token?>
  {
    private readonly IUserRepository _repository;
    private readonly IPasswordEncoder _passwordEncoder;
    private readonly ITokenEncoder _tokenEncoder;
    private readonly ITokenRepository _tokenRepository;
    public UserLoginHandler(IUserRepository repository, ITokenRepository tokenRepository, IPasswordEncoder passwordEncoder, ITokenEncoder tokenEncoder)
    {
      _repository = repository;
      _tokenRepository = tokenRepository;
      _passwordEncoder = passwordEncoder;
      _tokenEncoder = tokenEncoder;
    }

    public async Task<Token?> Handle(UserLogin argument, CancellationToken cancellationToken)
    {
      var user = await _repository.Get(argument.Email);

      if (user == null || !_passwordEncoder.Verify(user.Password, argument.Password))
      {
        return null;
      }

      var token = _tokenEncoder.Encode(user);
      await _tokenRepository.Add(token.Refresh);
      return token;
    }
  }
}