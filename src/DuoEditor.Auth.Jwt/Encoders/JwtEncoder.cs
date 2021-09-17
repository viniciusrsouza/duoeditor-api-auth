using System.Text.Json;
using DuoEditor.Auth.App.Interfaces;
using DuoEditor.Auth.Domain.Entities;
using DuoEditor.Auth.Domain.Enums;
using JWT.Algorithms;
using JWT.Builder;
using Microsoft.Extensions.Options;

namespace DuoEditor.Auth.Jwt
{
  public class JwtEncoder : ITokenEncoder
  {
    private readonly JwtConfig _config;

    public JwtEncoder(IOptionsMonitor<JwtConfig> optionsMonitor)
    {
      _config = optionsMonitor.CurrentValue;
    }
    public TokenModel? Decode(string token)
    {
      var json = JwtBuilder.Create()
                           .WithAlgorithm(new HMACSHA256Algorithm())
                           .WithSecret(_config.Secret)
                           .MustVerifySignature()
                           .Decode(token);

      var options = new JsonSerializerOptions();
      options.PropertyNameCaseInsensitive = true;
      return JsonSerializer.Deserialize<TokenModel>(json, options);
    }

    public Token Encode(User user)
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