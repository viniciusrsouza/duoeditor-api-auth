using AutoMapper;
using DuoEditor.Auth.App.UseCases;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DuoEditor.Auth.Api.Controllers
{
  [Route("api/tokens")]
  public class TokenController : BaseController
  {
    public TokenController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
    {
    }

    [HttpPost]
    public async Task<IActionResult> Login(UserLogin payload)
    {
      var user = await _mediator.Send(payload);
      if (user != null)
      {
        return Ok(user);
      }
      return NotFound();
    }
  }
}