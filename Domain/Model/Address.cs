using System.ComponentModel.DataAnnotations;

namespace Domain.Model
{
  public class Address:Entity
  {
    [StringLength(50)]
    public string Address1 { get; set; }

    [StringLength(50)]
    public string Address2 { get; set; }

    public string Suburb { get; set; }

    public string City { get; set; }

    [StringLength(10)]
    public string PostCode { get; set; }
  }
}