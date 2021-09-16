using DuoEditor.Auth.App.Interfaces;
using DuoEditor.Auth.App.Repositories;
using DuoEditor.Auth.Domain.Entities;
using DuoEditor.Auth.Domain.Exceptions;
using MediatR;

namespace DuoEditor.Auth.App.UseCases
{
  public class UserRegisterHandler : IRequestHandler<UserRegister, User?>
  {
    private IUserRepository _repository;
    private IPasswordEncryptor _passwordEncryptor;
    public UserRegisterHandler(IUserRepository repository, IPasswordEncryptor passwordEncryptor)
    {
      _repository = repository;
      _passwordEncryptor = passwordEncryptor;
    }

    public async Task<User?> Handle(UserRegister argument, CancellationToken cancellationToken)
    {
      var u = await _repository.Get(argument.Email);
      if (u != null)
      {
        throw new ExistingUserException(argument.Email);
      }

      var passwordHash = _passwordEncryptor.Encrypt(argument.Password);

      var user = new User(argument.FirstName, argument.LastName, argument.Email, passwordHash);

      return await _repository.Create(user);
    }
  }
}