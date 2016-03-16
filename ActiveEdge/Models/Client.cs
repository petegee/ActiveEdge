using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
    [UIHint("iCheck")]
    public bool IsSmoker { get; set; }

    [DisplayName("Current medications?")]
    public string CurrentMedications { get; set; }

    [DisplayName("Medical History")]
    public string PreviousAilments { get; set; }

    [DisplayName("GP/Health Practicioner Name?")]
    public string GeneralPractionerName { get; set; }

    [DisplayName("Have you received medical clearance?")]
    [UIHint("iCheck")]
    public bool MedicalClearance { get; set; }

    [DisplayName("Have you received massage therapy before?")]
    [UIHint("iCheck")]
    public bool HasHadPreviousTherapy { get; set; }

    [DisplayName("Touch Preference")]
    public TouchPreference TouchPreference { get; set; }
    //public ContraIndications ContraIndications { get; set; }

    [DisplayName("Sunburn")]
    [UIHint("iCheck")]
    public bool ContraIndicationsSunburn { get; set; }

    [DisplayName("Headache")]
    [UIHint("iCheck")]
    public bool ContraIndicationsHeadache { get; set; }

    [DisplayName("Asthma")]
    [UIHint("iCheck")]
    public bool ContraIndicationsAsthma { get; set; }

    [DisplayName("Diabetes")]
    [UIHint("iCheck")]
    public bool ContraIndicationsDiabetes { get; set; }

    [DisplayName("Epilepsy")]
    [UIHint("iCheck")]
    public bool ContraIndicationsEpilepsy { get; set; }

    [DisplayName("Depression")]
    [UIHint("iCheck")]
    public bool ContraIndicationsDepression { get; set; }

    [DisplayName("Hemophilia")]
    [UIHint("iCheck")]
    public bool ContraIndicationsHemophilia { get; set; }

    [DisplayName("Cuts, Burns, Bruises")]
    [UIHint("iCheck")]
    public bool ContraIndicationsCutsBurnsBruises { get; set; }

    [DisplayName("Severe Pain")]
    [UIHint("iCheck")]
    public bool ContraIndicationsSeverePain { get; set; }

    [DisplayName("Arteriosclerosis")]
    [UIHint("iCheck")]
    public bool ContraIndicationsArteriosclerosis { get; set; }

    [DisplayName("Varicose Veins")]
    [UIHint("iCheck")]
    public bool ContraIndicationsVaricoseVeins { get; set; }

    [DisplayName("Dizziness")]
    [UIHint("iCheck")]
    public bool ContraIndicationsDizziness { get; set; }

    [DisplayName("High Blood Pressure")]
    [UIHint("iCheck")]
    public bool ContraIndicationsHighBloodPressure { get; set; }

    [DisplayName("Low Blood Pressure")]
    [UIHint("iCheck")]
    public bool ContraIndicationsLowBloodPressure { get; set; }

    [DisplayName("Inflammation")]
    [UIHint("iCheck")]
    public bool ContraIndicationsImflammation { get; set; }

    [DisplayName("Sleep disturbance")]
    [UIHint("iCheck")]
    public bool ContraIndicationsSleepDisturbance { get; set; }

    [DisplayName("Pregnant")]
    [UIHint("iCheck")]
    public bool ContraIndicationsIsPregnant { get; set; }

    [DisplayName("Hernia")]
    [UIHint("iCheck")]
    public bool ContraIndicationsHernia { get; set; }

    [DisplayName("Cancer")]
    [UIHint("iCheck")]
    public bool ContraIndicationsCancer { get; set; }

    [DisplayName("Contact Lenses")]
    [UIHint("iCheck")]
    public bool ContraIndicationsContactLenses { get; set; }

    [DisplayName("Musculoskeletal Problems")]
    [UIHint("iCheck")]
    public bool ContraIndicationsMusculoskletalProblems { get; set; }

    [DisplayName("Irritated Skin Rash")]
    [UIHint("iCheck")]
    public bool ContraIndicationsIrritatedSkinRash { get; set; }

    [DisplayName("Cold or Flu")]
    [UIHint("iCheck")]
    public bool ContraIndicationsColdOrFlu { get; set; }
    
    [DisplayName("Stomach Ulcers")]
    [UIHint("iCheck")]
    public bool ContraIndicationsStomachUlcers { get; set; }

    [DisplayName("Pins/Pacemaker")]
    [UIHint("iCheck")]
    public bool ContraIndicationsPinsPacemaker { get; set; }

    [DisplayName("Heart Disease")]
    [UIHint("iCheck")]
    public bool ContraIndicationsHeartDisease { get; set; }
    
  }
}