using System.Text.Json;
using DuoEditor.Auth.App.Repositories;
using DuoEditor.Auth.Domain.Entities;
using DuoEditor.Auth.Infra.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DuoEditor.Auth.Infra.Repositories
{
  public class TokenRepository : ITokenRepository
  {
    private readonly ApiDbContext _context;

    public TokenRepository(ApiDbContext context)
    {
      _context = context;
    }

    public async Task<RefreshToken?> Create(RefreshToken token)
    {
      var entry = _context.RefreshTokens.Add(token);
      await _context.SaveChangesAsync();
      return entry.Entity;
    }

    public async Task<RefreshToken?> Delete(string token)
    {
      RefreshToken _token;
      try
      {
        _token = _context.RefreshTokens.Include(x => x.User).First(x => x.Value == token);
      }
      catch (Exception)
      {
        return null;
      }

      var entry = _context.RefreshTokens.Remove(_token);
      await _context.SaveChangesAsync();
      return entry.Entity;
    }

    public async Task<RefreshToken?> Get(string token)
    {
      try
      {
        return await Task.Run(() => _context.RefreshTokens.Include(x => x.User).First(x => x.Value == token));
      }
      catch (Exception)
      {
        return null;
      }
    }

    public async Task<RefreshToken?> Update(RefreshToken token)
    {
      var entry = _context.RefreshTokens.Update(token);
      await _context.SaveChangesAsync();
      return entry.Entity;
    }

    public async Task DeleteExpired()
    {
      var now = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

      _context
      .RefreshTokens
      .RemoveRange(
        _context
        .RefreshTokens
        .Where(x => x.Expiration < now)
      );

      await _context.SaveChangesAsync();
    }
  }
}