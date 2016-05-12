using System.Collections.Generic;

namespace Domain.Model
{
  public class ExerciseType
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public virtual ICollection<Client> Clients { get; set; }
  }
}