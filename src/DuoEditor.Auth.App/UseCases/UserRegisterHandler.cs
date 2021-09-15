using DuoEditor.Auth.App.Interfaces;
using DuoEditor.Auth.App.Repositories;
using DuoEditor.Auth.App.Validators;
using DuoEditor.Auth.Domain.Entities;
using DuoEditor.Auth.Domain.Exceptions;
using MediatR;

namespace DuoEditor.Auth.App.UseCases
{
  public class UserRegisterHandler : IRequestHandler<UserRegister, User>
  {
    private IUserRepository _repository;
    private IPasswordEncryptor _passwordEncryptor;
    public UserRegisterHandler(IUserRepository repository, IPasswordEncryptor passwordEncryptor)
    {
      _repository = repository;
      _passwordEncryptor = passwordEncryptor;
    }

    public Task<User> Handle(UserRegister argument, CancellationToken cancellationToken)
    {
      var u = _repository.Get(argument.Email);
      if (u != null)
      {
        throw new ExistingUserException(argument.Email);
      }

      if (argument.Password != argument.ConfirmPassword)
      {
        throw new PasswordsNotMatchingException();
      }

      PasswordValidator.Validate(argument.Password);

      var passwordHash = _passwordEncryptor.Encrypt(argument.Password);

      var user = new User(argument.FirstName, argument.LastName, argument.Email, passwordHash);
      user.Validate();

      return Task.FromResult(_repository.Create(user));
    }
  }
}