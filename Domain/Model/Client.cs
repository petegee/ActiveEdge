using System;
using Domain.Event;
using Marten.Schema;

namespace Domain.Model
{
    public class Client : Entity, IAmLinkedToAnOrganization
    {
        public Client()
        {
            Address = new Address();
            ContraIndications = new ContraIndications();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => FirstName + " " + LastName;
        public Gender Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public Address Address { get; set; }
        public ExcerciseFrequency ExcerciseFrequency { get; set; }
        public bool IsSmoker { get; set; }
        public string CurrentMedications { get; set; }
        public string PreviousAilments { get; set; }
        public string GeneralPractionerName { get; set; }
        public bool MedicalClearance { get; set; }
        public bool HasHadPreviousTherapy { get; set; }
        public TouchPreference TouchPreference { get; set; }
        public ContraIndications ContraIndications { get; set; }
        public int CurrentStressLevels { get; set; }
        public int CurrentPainOrTensionLevels { get; set; }
        public string Difficuties { get; set; }
        public string AreasNotToBeMassaged { get; set; }
        public TermsAndConditions TermsAndConditions { get; set; }
       

        [DuplicateField]
        public Guid OrganizationId { get; set; }

        public void Apply(ClientRegistered command)
        {
            FirstName = command.FirstName;
            LastName = command.LastName;
            Gender = command.Gender;
            DateOfBirth = command.DateOfBirth;
            Email = command.Email;
            ContactNumber = command.ContactNumber;
            Address.Line1 = command.AddressLine1;
            Address.Line2 = command.AddressLine2;
            Address.Suburb = command.Suburb;
            Address.City = command.City;
            ExcerciseFrequency = command.ExcerciseFrequency;
            IsSmoker = command.IsSmoker;
            CurrentMedications = command.CurrentMedications;
            PreviousAilments = command.PreviousAilments;
            GeneralPractionerName = command.GeneralPractionerName;
            MedicalClearance = command.MedicalClearance;
            HasHadPreviousTherapy = command.HasHadPreviousTherapy;
            TouchPreference = command.TouchPreference;
            ContraIndications.Arteriosclerosis = command.ContraIndicationsArteriosclerosis;
            ContraIndications.Arthritis = command.ContraIndicationsArthritis;
            ContraIndications.Asthma = command.ContraIndicationsAsthma;
            ContraIndications.Cancer = command.ContraIndicationsCancer;
            ContraIndications.ColdOrFlu = command.ContraIndicationsColdOrFlu;
            ContraIndications.ContactLenses = command.ContraIndicationsContactLenses;
            ContraIndications.CutsBurnsBruises = command.ContraIndicationsCutsBurnsBruises;
            ContraIndications.Depression = command.ContraIndicationsDepression;
            ContraIndications.Diabetes = command.ContraIndicationsDiabetes;
            ContraIndications.Dizziness = command.ContraIndicationsDizziness;
            ContraIndications.Epilepsy = command.ContraIndicationsEpilepsy;
            ContraIndications.Headache = command.ContraIndicationsHeadache;
            ContraIndications.HeartDisease = command.ContraIndicationsHeartDisease;
            ContraIndications.Hemophilia = command.ContraIndicationsHemophilia;
            ContraIndications.Hernia = command.ContraIndicationsHernia;
            ContraIndications.HighBloodPressure = command.ContraIndicationsHighBloodPressure;
            ContraIndications.Imflamation = command.ContraIndicationsImflammation;
            ContraIndications.IrritatedSkinRash = command.ContraIndicationsIrritatedSkinRash;
            ContraIndications.IsPregnant = command.ContraIndicationsIsPregnant;
            ContraIndications.LowBloodPressure = command.ContraIndicationsLowBloodPressure;
            ContraIndications.MusculoskeletalProblems = command.ContraIndicationsMusculoskletalProblems;
            ContraIndications.PinsPacemaker = command.ContraIndicationsPinsPacemaker;
            ContraIndications.SeverePain = command.ContraIndicationsSeverePain;
            ContraIndications.SleepDisturbance = command.ContraIndicationsSleepDisturbance;
            ContraIndications.StomachUlcers = command.ContraIndicationsStomachUlcers;
            ContraIndications.Sunburn = command.ContraIndicationsSunburn;
            ContraIndications.VaricoseVeins = command.ContraIndicationsVaricoseVeins;

            CurrentStressLevels = command.CurrentStressLevels;
            CurrentPainOrTensionLevels = command.CurrentPainOrTensionLevels;
            Difficuties = command.Difficulties;
            AreasNotToBeMassaged = command.AreasNotToBeMassaged;
            TermsAndConditions.Condition1 = command.TermsAndConditionsConditions1;
            TermsAndConditions.Condition2 = command.TermsAndConditionsConditions2;
            TermsAndConditions.Condition3 = command.TermsAndConditionsConditions3;
            TermsAndConditions.Condition4 = command.TermsAndConditionsConditions4;
            TermsAndConditions.Condition5 = command.TermsAndConditionsConditions5;
            TermsAndConditions.Condition6 = command.TermsAndConditionsConditions6;
            TermsAndConditions.Condition7 = command.TermsAndConditionsConditions7;
            TermsAndConditions.Condition8 = command.TermsAndConditionsConditions8;


            OrganizationId = command.OrganizationId;
        }
    }
}