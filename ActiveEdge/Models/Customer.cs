using System;
using System.ComponentModel;

namespace ActiveEdge.Models
{
  public class Customer
  {
    public int Id { get; set; }

    [DisplayName("First Name")]
    public string FirstName { get; set; }

    [DisplayName("Last Name")]
    public string LastName { get; set; }

    [DisplayName("Date Of Birth")]
    public DateTime? DateOfBirth { get; set; }

    [DisplayName("Email")]
    public string Email { get; set; }

    [DisplayName("Contact")]
    public string ContactNumber { get; set; }

    [DisplayName("Address Line 1")]
    public string AddressLine1 { get; set; }

    [DisplayName("Address Line 2")]
    public string AddressLine2 { get; set; }

    [DisplayName("Suburb")]
    public string Suburb { get; set; }

    [DisplayName("City")]
    public string City { get; set; }
  }
}