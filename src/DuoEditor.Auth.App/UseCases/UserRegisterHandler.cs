using DuoEditor.Auth.App.Repositories;
using DuoEditor.Auth.Domain.Entities;
using DuoEditor.Auth.Domain.Exceptions;
using MediatR;

namespace DuoEditor.Auth.App.UseCases
{
  public class UserRegisterHandler : IRequestHandler<UserRegister, User>
  {
    private IUserRepository _repository;
    public UserRegisterHandler(IUserRepository repository)
    {
      _repository = repository;
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

      var user = new User(argument.Name, argument.Email, argument.Password);
      user.Validate();

      return Task.FromResult(_repository.Create(user));
    }
  }
}