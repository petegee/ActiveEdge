using System.ComponentModel.DataAnnotations;

namespace Domain
{
  public class Address
  {
    [StringLength(50)]
    public string PhoneNumber { get; set; }

    [StringLength(50)]
    public string Address1 { get; set; }

    [StringLength(50)]
    public string Address2 { get; set; }

    public string City { get; set; }

    [StringLength(10)]
    public string PostCode { get; set; }
  }
}