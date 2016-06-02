using System;
using Domain.Model;

namespace Domain.Command
{
    public class RegisterNewClientCommand : ICommand
    {
        public int? OrganizationId { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        DateTime? DateOfBirth { get; set; }
        string Email { get; set; }
        string ContactNumber { get; set; }
        string AddressLine1 { get; set; }
        string AddressLine2 { get; set; }
        string Suburb { get; set; }
        string City { get; set; }
        Gender? Gender { get; set; }
        ExcerciseFrequency? ExcerciseFrequency { get; set; }
        bool IsSmoker { get; set; }
        string CurrentMedications { get; set; }
        string PreviousAilments { get; set; }
        string GeneralPractionerName { get; set; }
        bool MedicalClearance { get; set; }
        bool HasHadPreviousTherapy { get; set; }
        TouchPreference? TouchPreference { get; set; }
        bool ContraIndicationsSunburn { get; set; }
        bool ContraIndicationsHeadache { get; set; }
        bool ContraIndicationsAsthma { get; set; }
        bool ContraIndicationsDiabetes { get; set; }
        bool ContraIndicationsEpilepsy { get; set; }
        bool ContraIndicationsDepression { get; set; }
        bool ContraIndicationsHemophilia { get; set; }
        bool ContraIndicationsCutsBurnsBruises { get; set; }
        bool ContraIndicationsSeverePain { get; set; }
        bool ContraIndicationsArteriosclerosis { get; set; }
        bool ContraIndicationsVaricoseVeins { get; set; }
        bool ContraIndicationsDizziness { get; set; }
        bool ContraIndicationsHighBloodPressure { get; set; }
        bool ContraIndicationsLowBloodPressure { get; set; }
        bool ContraIndicationsImflammation { get; set; }
        bool ContraIndicationsSleepDisturbance { get; set; }
        bool ContraIndicationsIsPregnant { get; set; }
        bool ContraIndicationsHernia { get; set; }
        bool ContraIndicationsCancer { get; set; }
        bool ContraIndicationsContactLenses { get; set; }
        bool ContraIndicationsMusculoskletalProblems { get; set; }
        bool ContraIndicationsIrritatedSkinRash { get; set; }
        bool ContraIndicationsColdOrFlu { get; set; }
        bool ContraIndicationsStomachUlcers { get; set; }
        bool ContraIndicationsPinsPacemaker { get; set; }
        bool ContraIndicationsHeartDisease { get; set; }
        int CurrentStressLevels { get; set; }
        int CurrentPainOrTensionLevels { get; set; }
        string Difficulties { get; set; }
        string AreasNotToBeMassaged { get; set; }
        bool TermsAndConditionsConditions1 { get; set; }
        bool TermsAndConditionsConditions2 { get; set; }
        bool TermsAndConditionsConditions3 { get; set; }
        bool TermsAndConditionsConditions4 { get; set; }
        bool TermsAndConditionsConditions5 { get; set; }
        bool TermsAndConditionsConditions6 { get; set; }
        bool TermsAndConditionsConditions7 { get; set; }
        bool TermsAndConditionsConditions8 { get; set; }
    }
}