using System.ComponentModel.DataAnnotations;

namespace DuoEditor.Auth.Domain.Entities
{
  public abstract class Entity
  {
    [Key]
    public int Id { get; set; }
  }
}