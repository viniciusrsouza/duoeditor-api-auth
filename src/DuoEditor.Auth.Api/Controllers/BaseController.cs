using System.Security.Claims;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DuoEditor.Auth.Api.Controllers
{
  [ApiController]
  public class BaseController : ControllerBase
  {
    protected readonly IMediator _mediator;
    protected readonly IMapper _mapper;
    protected string? UserEmail => User.FindFirst(ClaimTypes.Email)?.Value;
    protected int? UserId
    {
      get
      {
        var idClaim = User.FindFirst("id");

        if (idClaim == null)
        {
          return null;
        }

        return int.Parse(idClaim.Value);
      }
    }

    public BaseController(IMediator mediator, IMapper mapper)
    {
      _mediator = mediator;
      _mapper = mapper;
    }
  }
}