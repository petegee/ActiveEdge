using System.Collections.Generic;

namespace Domain.Model
{
  public class Organisation:Entity
  {
    public string Name { get; set; }

    public virtual ICollection<Clinic> Clinics { get; set; }
  }
}
