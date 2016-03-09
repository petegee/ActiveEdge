using System;

namespace Domain
{
  public class Customer
    {
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Gender Gender { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string Email { get; set; }
    public string ContactNumber { get; set; }
    public string AddressLine1 { get; set; }
    public string AddressLine2 { get; set; }
    public string Suburb { get; set; }
    public string City { get; set; }
  }
}
