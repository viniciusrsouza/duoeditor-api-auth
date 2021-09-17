using System.Security.Claims;
using System.Text.Encodings.Web;
using DuoEditor.Auth.App.Interfaces;
using DuoEditor.Auth.Domain.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace DuoEditor.Auth.Jwt
{
  public class JwtAuthenticationHandler : AuthenticationHandler<JwtAuthenticationOptions>
  {
    private readonly ITokenEncoder _jwtEncoder;
    public JwtAuthenticationHandler(ITokenEncoder jwtEncoder, IOptionsMonitor<JwtAuthenticationOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) : base(options, logger, encoder, clock)
    {
      _jwtEncoder = jwtEncoder;
    }

    protected override Task<AuthenticateResult> HandleAuthenticateAsync()
    {
      var authorizationHeader = Context.Request.Headers["Authorization"];
      if (!authorizationHeader.Any())
      {
        return Task.FromResult(AuthenticateResult.Fail("No authentication token provided"));
      }

      var value = authorizationHeader.ToString().Split(' ').LastOrDefault("");
      if (string.IsNullOrWhiteSpace(value))
      {
        return Task.FromResult(AuthenticateResult.Fail("No authentication token provided"));
      }

      TokenModel? tokenModel;
      try
      {
        tokenModel = _jwtEncoder.Decode(value);
        if (tokenModel == null)
        {
          return Task.FromResult(AuthenticateResult.Fail("The Authentication token is not valid"));
        }
      }
      catch
      {
        return Task.FromResult(AuthenticateResult.Fail("The Authentication token is not valid"));
      }

      var decoded = _jwtEncoder.Decode(value);

      var claims = new[] {
          new Claim("id", tokenModel.Id.ToString()),
          new Claim(ClaimTypes.Email, tokenModel.Email)
      };

      // create a new claims identity and return an AuthenticationTicket 
      // with the correct scheme
      var claimsIdentity = new ClaimsIdentity(claims, nameof(JwtAuthenticationHandler));
      var ticket = new AuthenticationTicket(new ClaimsPrincipal(claimsIdentity), Scheme.Name);

      return Task.FromResult(AuthenticateResult.Success(ticket));
    }
  }
}