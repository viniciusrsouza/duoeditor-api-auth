using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace DuoEditor.Auth.App.Config
{
  public static class DIConfig
  {
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
      services.AddMediatR(Assembly.GetExecutingAssembly());

      return services;
    }
  }
}