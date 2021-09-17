using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DuoEditor.Auth.Api.Controllers
{
  [ApiController]
  public class BaseController : ControllerBase
  {
    protected IMediator _mediator;

    public BaseController(IMediator mediator)
    {
      _mediator = mediator;
    }
  }
}