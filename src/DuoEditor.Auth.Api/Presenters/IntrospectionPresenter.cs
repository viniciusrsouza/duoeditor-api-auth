namespace DuoEditor.Auth.Api.Presenters
{
  public class IntrospectionPresenter
  {
    public AuthUserPresenter User { get; set; } = null!;
    public long Expiration { get; set; }

    public IntrospectionPresenter(AuthUserPresenter user, long expiration)
    {
      User = user;
      Expiration = expiration;
    }
  }
}