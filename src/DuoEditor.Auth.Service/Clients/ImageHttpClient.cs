using System.Text.Json;
using DuoEditor.Auth.App.Repositories;
using DuoEditor.Auth.Domain.Entities;
using DuoEditor.Auth.Service.Config;
using DuoEditor.Auth.Service.Models;
using Microsoft.Extensions.Options;

namespace DuoEditor.Auth.Service.Clients
{
  public class ImageHttpClient : IImageRepository
  {
    public readonly HttpClient _client;
    public readonly ImageClientConfig _config;

    public ImageHttpClient(HttpClient client, IOptions<ImageClientConfig> options)
    {
      _config = options.Value;
      client.BaseAddress = new Uri(_config.ServiceUrl);
      _client = client;
    }

    public async Task<string?> GetImage(User user)
    {
      try
      {
        var response = await _client.GetAsync($"{_config.UserImageEndpoint}/{user.Id}");
        var json = await response.Content.ReadAsStringAsync();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        var parsedResponse = JsonSerializer.Deserialize<GetUserImageResponse>(json, options);
        return parsedResponse?.FileName;
      }
      catch
      {
        return null;
      }
    }
  }
}