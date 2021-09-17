using AutoMapper;
using DuoEditor.Auth.Api.Presenters;
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
    public UserController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
    {
    }

    [HttpPost]
    public async Task<IActionResult> Register(UserRegister payload)
    {
      try
      {
        var user = await _mediator.Send(payload);
        return Ok(_mapper.Map<AuthUserPresenter>(user));
      }
      catch (ExistingUserException ex)
      {
        return ValidationProblem(new ValidationProblemDetails(ex.errors));
      }
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> Get()
    {
      var user = await _mediator.Send(new GetUser { Id = UserId });

      if (user == null)
      {
        return NotFound();
      }

      return Ok(_mapper.Map<AuthUserPresenter>(user));
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
      var user = await _mediator.Send(new GetUser { Id = id });

      if (user == null)
      {
        return NotFound();
      }

      return Ok(_mapper.Map<UserPresenter>(user));
    }
  }
}