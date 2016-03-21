﻿using System;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
  public enum TouchPreference
  {
    Light,
    Heavy,
    Deep,
  }
  public enum ExcerciseFrequency
  {

    Never,
    [Display(Name = "Once A Week")]
    OnceAWeek,
    [Display(Name = "Twice A Week")]
    TwiceAWeek,
    [Display(Name = "Three Times A Week")]
    ThreeTimesAWeek,
    [Display(Name = "Four Times A Week")]
    FourTimesAWeek,
    [Display(Name = "Five Times A Week")]
    FiveTimesAWeek,
    [Display(Name = "Six Times A Week")]
    SixTimesAWeek,
    [Display(Name = "Seven Times A Week")]
    SevenTimesAWeek,
    [Display(Name = "Seven+ A Week")]
    SevenPlusTimesAWeek
  }

  public class ExerciseType
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public virtual ICollection<Client> Clients { get; set; }
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
  }
}
