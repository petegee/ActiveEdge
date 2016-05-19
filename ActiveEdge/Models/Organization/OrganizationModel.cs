using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ActiveEdge.Models.Organization
{
  public class OrganizationModel
  {
    /// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
    public OrganizationModel()
    {
      Address = new AddressModel();
    }

    public int Id { get; set; }

    [DisplayName("Organization Name")]
    [Required]
    public string OrganizationName { get; set; }

    [DisplayName("Contact Name")]
    [Required]
    public string ContactPerson { get; set; }

    [DisplayName("Contact Number")]
    [Required]
    public string ContactPhoneNumber { get; set; }

    [DisplayName("Contact Email Address")]
    [EmailAddress]
    [Required]
    public string ContactEmailAddress { get; set; }

    public AddressModel Address { get; set; }
  }
}