using AutoMapper;
using DuoEditor.Auth.Api.Presenters;
using DuoEditor.Auth.App.UseCases;
using DuoEditor.Auth.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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

    [HttpPatch]
    public async Task<IActionResult> Refresh(TokenRefresh payload)
    {
      var token = await _mediator.Send(payload);
      if (token != null)
      {
        return Ok(token);
      }
      return Unauthorized();
    }

    [HttpPost("introspection")]
    public async Task<IActionResult> Introspection(Introspection payload)
    {
      var response = await _mediator.Send(payload);
      if (response == null)
      {
        return Unauthorized();
      }

      var (user, token) = ((User, TokenModel))response;
      return Ok(new IntrospectionPresenter(_mapper.Map<AuthUserPresenter>(user), token.Exp));
    }

    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> SignOff(RevokeToken payload)
    {
      await _mediator.Send(payload);
      return Ok();
    }
  }
} 