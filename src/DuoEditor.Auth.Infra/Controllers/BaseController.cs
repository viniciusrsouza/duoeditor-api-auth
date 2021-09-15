using DuoEditor.Auth.App.UseCases;
using DuoEditor.Auth.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DuoEditor.Auth.Infra.Controllers
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