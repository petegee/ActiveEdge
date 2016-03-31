using System;

using System.Collections.Generic;

namespace Domain
{
  public class TermsAndConditions
  {
    public bool Condition1 { get; set; }
    public bool Condition2 { get; set; }
    public bool Condition3 { get; set; }
    public bool Condition4 { get; set; }
    public bool Condition5 { get; set; }
    public bool Condition6 { get; set; }
    public bool Condition7 { get; set; }
    public bool Condition8 { get; set; }
  }

  public class Client
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
    public ExcerciseFrequency ExcerciseFrequency { get; set; }
    public virtual ICollection<ExerciseType> ExcerciseTypes { get; set; }
    public bool IsSmoker { get; set; }
    public string CurrentMedications { get; set; }
    public string PreviousAilments { get; set; }
    public string GeneralPractionerName { get; set; }
    public bool GPClearance { get; set; }
    public bool HasHadPreviousTherapy { get; set; }
    public TouchPreference TouchPreference { get; set; }
    public ContraIndications ContraIndications { get; set; }
    public int CurrentStressLevels { get; set; }
    public int CurrentPainOrTensionLevels { get; set; }
    public string Difficuties { get; set; }
    public string AreasNotToBeMassaged { get; set; }
    public TermsAndConditions TermsAndConditions { get; set; }
  }
}
