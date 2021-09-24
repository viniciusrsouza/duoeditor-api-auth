using DuoEditor.Auth.App.Interfaces;
using DuoEditor.Auth.App.Repositories;
using DuoEditor.Auth.Infra.Encoders;
using DuoEditor.Auth.Infra.Persistence;
using DuoEditor.Auth.Infra.Repositories;
using DuoEditor.Auth.Jwt;
using DuoEditor.Auth.Service.Clients;

namespace DuoEditor.Auth.Api.Config
{
  public static class DIConfig
  {
    public static IServiceCollection AddDependencies(this IServiceCollection services)
    {
      services.AddScoped<ApiDbContext>();
      services.AddScoped<IUserRepository, UserRepository>();
      services.AddScoped<ITokenRepository, TokenRepository>();
      services.AddScoped<IPasswordEncoder, BcryptPasswordEncoder>();
      services.AddScoped<ITokenEncoder, JwtEncoder>();
      services.AddSingleton<IImageRepository, ImageHttpClient>();

      return services;
    }
  }
}