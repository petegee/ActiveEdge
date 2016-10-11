using System;
using Domain.Model;
using Shared;

namespace Domain.Command.Client
{
    public class RegisterNewClient: IAsyncCommand
    {
        public Guid? OrganizationId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string Suburb { get; set; }
        public string City { get; set; }
        public Gender Gender { get; set; }
        public ExcerciseFrequency ExcerciseFrequency { get; set; }
        public bool IsSmoker { get; set; }
        public string CurrentMedications { get; set; }
        public string PreviousAilments { get; set; }
        public string GeneralPractionerName { get; set; }
        public bool MedicalClearance { get; set; }
        public bool HasHadPreviousTherapy { get; set; }
        public TouchPreference TouchPreference { get; set; }
        public bool ContraIndicationsSunburn { get; set; }
        public bool ContraIndicationsHeadache { get; set; }
        public bool ContraIndicationsArthritis { get; set; }
        public bool ContraIndicationsAsthma { get; set; }
        public bool ContraIndicationsDiabetes { get; set; }
        public bool ContraIndicationsEpilepsy { get; set; }
        public bool ContraIndicationsDepression { get; set; }
        public bool ContraIndicationsHemophilia { get; set; }
        public bool ContraIndicationsCutsBurnsBruises { get; set; }
        public bool ContraIndicationsSeverePain { get; set; }
        public bool ContraIndicationsArteriosclerosis { get; set; }
        public bool ContraIndicationsVaricoseVeins { get; set; }
        public bool ContraIndicationsDizziness { get; set; }
        public bool ContraIndicationsHighBloodPressure { get; set; }
        public bool ContraIndicationsLowBloodPressure { get; set; }
        public bool ContraIndicationsImflammation { get; set; }
        public bool ContraIndicationsSleepDisturbance { get; set; }
        public bool ContraIndicationsIsPregnant { get; set; }
        public bool ContraIndicationsHernia { get; set; }
        public bool ContraIndicationsCancer { get; set; }
        public bool ContraIndicationsContactLenses { get; set; }
        public bool ContraIndicationsMusculoskletalProblems { get; set; }
        public bool ContraIndicationsIrritatedSkinRash { get; set; }
        public bool ContraIndicationsColdOrFlu { get; set; }
        public bool ContraIndicationsStomachUlcers { get; set; }
        public bool ContraIndicationsPinsPacemaker { get; set; }
        public bool ContraIndicationsHeartDisease { get; set; }
        public int CurrentStressLevels { get; set; }
        public int CurrentPainOrTensionLevels { get; set; }
        public string Difficulties { get; set; }
        public string AreasNotToBeMassaged { get; set; }
        public bool TermsAndConditionsConditions1 { get; set; }
        public bool TermsAndConditionsConditions2 { get; set; }
        public bool TermsAndConditionsConditions3 { get; set; }
        public bool TermsAndConditionsConditions4 { get; set; }
        public bool TermsAndConditionsConditions5 { get; set; }
        public bool TermsAndConditionsConditions6 { get; set; }
        public bool TermsAndConditionsConditions7 { get; set; }
        public bool TermsAndConditionsConditions8 { get; set; }
    }
}