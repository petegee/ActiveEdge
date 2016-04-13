using System.ComponentModel.DataAnnotations;

namespace Domain
{
  public abstract class DomainModelBase
  {
    public int Id { get; set; }

    [Timestamp]
    public byte[] RowVersion { get; set; }
  }
}