using DuoEditor.Auth.App.Repositories;
using DuoEditor.Auth.Infra.Persistence;
using DuoEditor.Auth.Infra.Repositories;

namespace DuoEditor.Auth.Infra.Config
{
  public static class DIConfig
  {
    public static IServiceCollection AddDependencies(this IServiceCollection services)
    {
      services.AddScoped<ApiDbContext>();
      services.AddScoped<IUserRepository, UserRepository>();

      return services;
    }
  }
}