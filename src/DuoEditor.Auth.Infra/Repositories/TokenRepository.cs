using DuoEditor.Auth.App.Repositories;
using ServiceStack.Redis;

namespace DuoEditor.Auth.Infra.Repositories
{
  public class TokenRepository : ITokenRepository
  {
    private readonly IRedisClientsManagerAsync _manager;

    public TokenRepository(IRedisClientsManagerAsync manager)
    {
      _manager = manager;
    }

    public async Task<bool> Add(string token)
    {
      await using var redis = await _manager.GetClientAsync();
      await redis.AddAsync(token, 1);
      return await redis.ExpireEntryInAsync(token, TimeSpan.FromSeconds(30));
    }

    public async Task<bool> Has(string token)
    {
      await using var redis = await _manager.GetClientAsync();
      return await redis.ContainsKeyAsync(token);
    }

    public async Task<bool> Remove(string token)
    {
      await using var redis = await _manager.GetClientAsync();
      return await redis.RemoveAsync(token);
    }

    public async Task<bool> Replace(string token, string newToken)
    {
      await using var redis = await _manager.GetClientAsync();
      if (await redis.ContainsKeyAsync(token))
      {
        var removed = await redis.RemoveAsync(token);
        var added = await redis.AddAsync(token, 1);
        var expiring = await redis.ExpireEntryInAsync(newToken, TimeSpan.FromSeconds(30));
        return removed && added && expiring;
      }
      return false;
    }
  }
}