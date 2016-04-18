using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
  public class Organisation:Entity
  {
    public string Name { get; set; }

    public virtual ICollection<Clinic> Clinics { get; set; }
  }
}
