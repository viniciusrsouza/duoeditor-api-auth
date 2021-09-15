using DuoEditor.Auth.App.UseCases;
using DuoEditor.Auth.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DuoEditor.Auth.Infra.Controllers
{
  [Route("api/users")]
  public class UserController : BaseController
  {
    public UserController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    public async Task<IActionResult> Post(UserRegister payload)
    {
      try
      {
        var r = await _mediator.Send(payload);
        return Ok(r);
      }
      catch (Exception ex)
      {
        return BadRequest(new { Message = ex.Message });
      }
    }
  }
}