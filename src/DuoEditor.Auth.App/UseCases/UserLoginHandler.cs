using DuoEditor.Auth.App.Interfaces;
using DuoEditor.Auth.App.Repositories;
using DuoEditor.Auth.Domain.Entities;
using MediatR;

namespace DuoEditor.Auth.App.UseCases
{
  public class UserLoginHandler : IRequestHandler<UserLogin, Token?>
  {
    private readonly IUserRepository _repository;
    private readonly IPasswordEncryptor _passwordEncryptor;
    private readonly ITokenEncryptor _tokenEncryptor;
    public UserLoginHandler(IUserRepository repository, IPasswordEncryptor passwordEncryptor, ITokenEncryptor tokenEncryptor)
    {
      _repository = repository;
      _passwordEncryptor = passwordEncryptor;
      _tokenEncryptor = tokenEncryptor;
    }

    public async Task<Token?> Handle(UserLogin argument, CancellationToken cancellationToken)
    {
      var user = await _repository.Get(argument.Email);

      if (user == null || !_passwordEncryptor.Verify(user.Password, argument.Password))
      {
        return null;
      }

      return _tokenEncryptor.Encrypt(user);
    }
  }
}