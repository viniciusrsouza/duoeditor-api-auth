using DuoEditor.Auth.App.UseCases;
using MediatR;

namespace DuoEditor.Auth.Api.Tasks
{
  public class TokenCleanupService : IHostedService, IDisposable
  {
    private Timer? _timer;
    private IMediator _mediator;

    public TokenCleanupService(IMediator mediator)
    {
      _mediator = mediator;
    }

    private void DoWork(object? state)
    {
      _mediator.Send(new CleanupTokens());
    }

    public void Dispose()
    {
      _timer?.Dispose();
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
      _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromHours(6));
      return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
      _timer?.Change(Timeout.Infinite, 0);
      return Task.CompletedTask;
    }
  }
}