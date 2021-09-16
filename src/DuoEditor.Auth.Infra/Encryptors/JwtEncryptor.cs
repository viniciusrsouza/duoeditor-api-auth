using DuoEditor.Auth.App.Interfaces;
using DuoEditor.Auth.Domain.Entities;
using DuoEditor.Auth.Domain.Enums;
using JWT.Algorithms;
using JWT.Builder;
using Microsoft.Extensions.Options;

namespace DuoEditor.Auth.Infra.Encryptors
{
  public class JwtEncryptor : ITokenEncryptor
  {
    private readonly JwtConfig _config;

    public JwtEncryptor(IOptionsMonitor<JwtConfig> optionsMonitor)
    {
      _config = optionsMonitor.CurrentValue;
    }
    public Dictionary<string, string> Decrypt(string token)
    {
      throw new NotImplementedException();
    }

    public Token Encrypt(User user)
    {
      var refresh = JwtBuilder.Create()
                              .WithAlgorithm(new HMACSHA256Algorithm())
                              .WithSecret(_config.Secret)
                              .AddClaim("exp", DateTimeOffset.UtcNow.AddHours(24).ToUnixTimeSeconds())
                              .AddClaim("type", TokenType.Refresh)
                              .Encode();

      var access = JwtBuilder.Create()
                              .WithAlgorithm(new HMACSHA256Algorithm())
                              .WithSecret(_config.Secret)
                              .AddClaim("exp", DateTimeOffset.UtcNow.AddHours(1).ToUnixTimeSeconds())
                              .AddClaim("type", TokenType.Access)
                              .AddClaim("email", user.Email)
                              .AddClaim("id", user.Id)
                              .Encode();

      return new Token { Refresh = refresh, Access = access };
    }
  }
}