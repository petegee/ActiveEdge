namespace ActiveEdge.Models.Organization
{
  public class OrganizationModel
  {
    public int Id { get; set; }

    public string OrganizationName { get; set; }

    public string ContactPerson { get; set; }

    public string ContactPhoneNumber { get; set; }

    public string ContactEmaiAddress { get; set; }

    public AddressModel Address { get; set; }
  }
}