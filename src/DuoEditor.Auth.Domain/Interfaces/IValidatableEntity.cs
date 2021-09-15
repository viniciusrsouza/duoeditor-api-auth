namespace DuoEditor.Auth.Domain.Interfaces
{
  public interface IValidatableEntity
  {
    void Validate();
    bool IsValid()
    {
      try
      {
        Validate();
        return true;
      }
      catch
      {
        return false;
      }
    }
  }
}