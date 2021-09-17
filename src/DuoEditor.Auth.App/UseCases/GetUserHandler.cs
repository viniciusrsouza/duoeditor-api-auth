using DuoEditor.Auth.App.Repositories;
using DuoEditor.Auth.Domain.Entities;
using MediatR;

namespace DuoEditor.Auth.App.UseCases
{
  public class GetUserHandler : IRequestHandler<GetUser, User?>
  {
    private IUserRepository _repository;
    public GetUserHandler(IUserRepository repository)
    {
      _repository = repository;
    }

    public async Task<User?> Handle(GetUser argument, CancellationToken cancellationToken)
    {
      if (argument.Id != null)
      {
        return await _repository.Get((int)argument.Id);
      }

      if (argument.Email != null)
      {
        return await _repository.Get(argument.Email);
      }

      return null;
    }
  }
}