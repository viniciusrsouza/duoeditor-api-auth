using DuoEditor.Auth.App.Repositories;
using DuoEditor.Auth.Domain.Entities;
using MediatR;

namespace DuoEditor.Auth.App.UseCases
{
  public class GetUserHandler : IRequestHandler<GetUser, User?>
  {
    private readonly IUserRepository _repository;
    private readonly IImageRepository _imageRepository;
    public GetUserHandler(IUserRepository repository, IImageRepository imageRepository)
    {
      _repository = repository;
      _imageRepository = imageRepository;
    }

    public async Task<User?> Handle(GetUser argument, CancellationToken cancellationToken)
    {
      User? user = null;
      if (argument.Id != null)
      {
        user = await _repository.Get((int)argument.Id);
      }

      if (user == null && argument.Email != null)
      {
        user = await _repository.Get(argument.Email);
      }

      if (user != null)
      {
        var image = await _imageRepository.GetImage(user);
        user.ProfileImage = image;
      }
      return user;
    }
  }
}