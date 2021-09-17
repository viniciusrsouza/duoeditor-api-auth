using DuoEditor.Auth.Domain.Entities;
using MediatR;

namespace DuoEditor.Auth.App.UseCases
{
  public class GetUser : IRequest<User>
  {
    public string? Email { get; set; }

    public int? Id { get; set; }
  }
}