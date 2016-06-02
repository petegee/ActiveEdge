using System;
using Domain.Model;

namespace Domain.Command
{
    public class UpdateClientCommand : ICommand
    {
        private string FirstName { get; set; }
        private string LastName { get; set; }
        private DateTime? DateOfBirth { get; set; }
        private string Email { get; set; }
        private string ContactNumber { get; set; }
        private string AddressLine1 { get; set; }
        private string AddressLine2 { get; set; }
        private string Suburb { get; set; }
        private string City { get; set; }
        private Gender? Gender { get; set; }
        private ExcerciseFrequency? ExcerciseFrequency { get; set; }
        private bool IsSmoker { get; set; }
        private string CurrentMedications { get; set; }
        private string PreviousAilments { get; set; }
        private string GeneralPractionerName { get; set; }
        private bool MedicalClearance { get; set; }
        private bool HasHadPreviousTherapy { get; set; }
        private TouchPreference? TouchPreference { get; set; }
        private bool ContraIndicationsSunburn { get; set; }
        private bool ContraIndicationsHeadache { get; set; }
        private bool ContraIndicationsAsthma { get; set; }
        private bool ContraIndicationsDiabetes { get; set; }
        private bool ContraIndicationsEpilepsy { get; set; }
        private bool ContraIndicationsDepression { get; set; }
        private bool ContraIndicationsHemophilia { get; set; }
        private bool ContraIndicationsCutsBurnsBruises { get; set; }
        private bool ContraIndicationsSeverePain { get; set; }
        private bool ContraIndicationsArteriosclerosis { get; set; }
        private bool ContraIndicationsVaricoseVeins { get; set; }
        private bool ContraIndicationsDizziness { get; set; }
        private bool ContraIndicationsHighBloodPressure { get; set; }
        private bool ContraIndicationsLowBloodPressure { get; set; }
        private bool ContraIndicationsImflammation { get; set; }
        private bool ContraIndicationsSleepDisturbance { get; set; }
        private bool ContraIndicationsIsPregnant { get; set; }
        private bool ContraIndicationsHernia { get; set; }
        private bool ContraIndicationsCancer { get; set; }
        private bool ContraIndicationsContactLenses { get; set; }
        private bool ContraIndicationsMusculoskletalProblems { get; set; }
        private bool ContraIndicationsIrritatedSkinRash { get; set; }
        private bool ContraIndicationsColdOrFlu { get; set; }
        private bool ContraIndicationsStomachUlcers { get; set; }
        private bool ContraIndicationsPinsPacemaker { get; set; }
        private bool ContraIndicationsHeartDisease { get; set; }
        private int CurrentStressLevels { get; set; }
        private int CurrentPainOrTensionLevels { get; set; }
        private string Difficulties { get; set; }
        private string AreasNotToBeMassaged { get; set; }
        private bool TermsAndConditionsConditions1 { get; set; }
        private bool TermsAndConditionsConditions2 { get; set; }
        private bool TermsAndConditionsConditions3 { get; set; }
        private bool TermsAndConditionsConditions4 { get; set; }
        private bool TermsAndConditionsConditions5 { get; set; }
        private bool TermsAndConditionsConditions6 { get; set; }
        private bool TermsAndConditionsConditions7 { get; set; }
        private bool TermsAndConditionsConditions8 { get; set; }
    }
}