using DuoEditor.Auth.App.Interfaces;
using DuoEditor.Auth.App.Repositories;
using DuoEditor.Auth.Infra.Encoders;
using DuoEditor.Auth.Infra.Persistence;
using DuoEditor.Auth.Infra.Repositories;
using DuoEditor.Auth.Jwt;

namespace DuoEditor.Auth.Infra.Config
{
  public static class DIConfig
  {
    public static IServiceCollection AddDependencies(this IServiceCollection services)
    {
      services.AddScoped<ApiDbContext>();
      services.AddScoped<IUserRepository, UserRepository>();
      services.AddScoped<IPasswordEncoder, BcryptPasswordEncoder>();
      services.AddScoped<ITokenEncoder, JwtEncoder>();

      return services;
    }
  }
}