namespace DuoEditor.Auth.App.Interfaces
{
  public interface IUseCaseHandler<T, R>
  {
    R handle(T argument);
  }
}