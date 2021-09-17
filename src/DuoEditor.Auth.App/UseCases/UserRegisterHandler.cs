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
    private IPasswordEncoder _passwordEncoder;
    public UserRegisterHandler(IUserRepository repository, IPasswordEncoder passwordEncoder)
    {
      _repository = repository;
      _passwordEncoder = passwordEncoder;
    }

    public async Task<User?> Handle(UserRegister argument, CancellationToken cancellationToken)
    {
      var u = await _repository.Get(argument.Email);
      if (u != null)
      {
        throw new ExistingUserException(argument.Email);
      }

      var passwordHash = _passwordEncoder.Encode(argument.Password);

      var user = new User(argument.FirstName, argument.LastName, argument.Email, passwordHash);

      return await _repository.Create(user);
    }
  }
}