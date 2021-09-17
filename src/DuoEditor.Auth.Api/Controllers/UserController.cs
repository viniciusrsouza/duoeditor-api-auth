using DuoEditor.Auth.App.UseCases;
using DuoEditor.Auth.Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DuoEditor.Auth.Api.Controllers
{
  [Route("api/users")]
  public class UserController : BaseController
  {
    public UserController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Create(UserRegister payload)
    {
      try
      {
        var r = await _mediator.Send(payload);
        return Ok(r);
      }
      catch (ExistingUserException ex)
      {
        return ValidationProblem(new ValidationProblemDetails(ex.errors));
      }
    }
  }
}