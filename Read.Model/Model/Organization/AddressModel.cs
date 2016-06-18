using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ActiveEdge.Read.Model.Organization
{
  public class AddressModel
  {
    [DisplayName("Address Line 1")]
    [Required]
    public string AddressLine1 { get; set; }

    [DisplayName("Address Line 2")]
    public string AddressLine2 { get; set; }

    [DisplayName("Suburb")]
    [Required]
    public string Suburb { get; set; }

    [DisplayName("City")]
    [Required]
    public string City { get; set; }
  }
}