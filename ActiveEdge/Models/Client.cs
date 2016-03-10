using System;
using System.ComponentModel;
using Domain;

namespace ActiveEdge.Models
{
  public class Client
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
    
    public Gender Gender { get; set; }

    [DisplayName("Excercise Frequency")]
    public ExcerciseFrequency ExcerciseFrequency { get; set; }

    [DisplayName("Do you smoke?")]
    public bool IsSmoker { get; set; }

    [DisplayName("What medications are you currently using?")]
    public string CurrentMedications { get; set; }

    [DisplayName("Previous complaints/surgeries/medications")]
    public string PreviousAilments { get; set; }

    [DisplayName("GP/Health Practicioner Name?")]
    public string GeneralPractionerName { get; set; }

    [DisplayName("Have you received medical clearance?")]
    public bool MedicalClearance { get; set; }

    [DisplayName("Have you received massage therapy before?")]
    public bool HasHadPreviousTherapy { get; set; }

    public TouchPreference TouchPreference { get; set; }
    //public ContraIndications ContraIndications { get; set; }
  }
}