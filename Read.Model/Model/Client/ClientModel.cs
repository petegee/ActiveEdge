using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Domain.Event;
using Domain.Event.Session;
using Domain.Model;

namespace ActiveEdge.Read.Model.Client
{
    public class ClientModel: IAmLinkedToAnOrganization
    {

        public ClientModel()
        {
            SessionCount = 0;
        }

        public int SessionCount { get; set; }

        public Guid Id { get; set; }

        [DisplayName("Full Name")]
        public string FullName => $"{FirstName} {LastName}";

        [DisplayName("First Name")]
        [Required]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        [Required]
        public string LastName { get; set; }

        [DisplayName("Date Of Birth")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }

        [DisplayName("Email")]
        [Required]
        public string Email { get; set; }

        [DisplayName("Contact Number")]
        [Required]
        public string ContactNumber { get; set; }

        [DisplayName("Address Line 1")]
        [Required]
        public string AddressLine1 { get; set; }

        [DisplayName("Address Line 2")]
        public string AddressLine2 { get; set; }

        [DisplayName("Suburb")]
        [Required]
        public string Suburb { get; set; }

        [DisplayName("City")]
        [Required]
        public string City { get; set; }

        [Required]
        public Gender? Gender { get; set; }

        [DisplayName("Excercise Frequency")]
        [Required]
        public ExcerciseFrequency? ExcerciseFrequency { get; set; }

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
        [Required]
        public TouchPreference? TouchPreference { get; set; }

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

        [DisplayName("Current Stress Levels")]
        [Range(0, 10)]
        public int CurrentStressLevels { get; set; }

        [DisplayName("Current Pain/Tension Levels")]
        [Range(0, 10)]
        public int CurrentPainOrTensionLevels { get; set; }

        [DisplayName("Do you have any difficulty laying on your front / back / side? How can we make you comfortable")]
        public string Difficulties { get; set; }

        [DisplayName("Are there any areas that you would not like massaged? (E.g feet, head)")]
        public string AreasNotToBeMassaged { get; set; }

        [DisplayName(
            "I understand that I am booked in for a relaxation / sports massage and I am not here for treatment to injury."
            )]
        [UIHint("iCheck")]
        public bool TermsAndConditionsConditions1 { get; set; }

        [DisplayName(
            "I understand that my feedback is encouraged not only after the massage but also throughout so you can get the most out of your massage."
            )]
        [UIHint("iCheck")]
        public bool TermsAndConditionsConditions2 { get; set; }

        [DisplayName("I understand payment must be made at the time of appointment if not beforehand.")]
        [UIHint("iCheck")]
        public bool TermsAndConditionsConditions3 { get; set; }

        [DisplayName(
            "I understand the Active Edge late arrival and cancellation policy (less than 24 hours notice or booking changes may be subject to a cancellation fee.Massage session will not be extended due to late arrival)."
            )]
        [UIHint("iCheck")]
        public bool TermsAndConditionsConditions4 { get; set; }

        [DisplayName(
            "I understand that massage therapy is designed to be a health aid and does not take place of primary care.")
        ]
        [UIHint("iCheck")]
        public bool TermsAndConditionsConditions5 { get; set; }

        [DisplayName(
            "I understand that I must contact Active Edge and consult my health practitioner if I have medical conditions that become aggravated or if I have severe ongoing effects after the massage."
            )]
        [UIHint("iCheck")]
        public bool TermsAndConditionsConditions6 { get; set; }

        [DisplayName(
            "I am aware that I may experience mild discomfort, headaches, or tiredness after the massage. This is a normal response to massage. Post massage recommendations are to increase water intake and avoid strenuous exercise for 12 hours."
            )]
        [UIHint("iCheck")]
        public bool TermsAndConditionsConditions7 { get; set; }

        [DisplayName(
            "I understand that each massage session will include time for consultation and assessment so we can appreciate your condition to give you an effective massage."
            )]
        [UIHint("iCheck")]
        public bool TermsAndConditionsConditions8 { get; set; }

        public bool ContraIndicationsArthritis { get; set; }

        public void Apply(ClientRegistered domainEvent)
        {
            OrganizationId = domainEvent.OrganizationId;
            FirstName = domainEvent.FirstName;
            LastName = domainEvent.LastName;
            Gender = domainEvent.Gender;
            DateOfBirth = domainEvent.DateOfBirth;
            Email = domainEvent.Email;
            ContactNumber = domainEvent.ContactNumber;
            AddressLine1 = domainEvent.AddressLine1;
            AddressLine2 = domainEvent.AddressLine2;
            Suburb = domainEvent.Suburb;
            City = domainEvent.City;
            ExcerciseFrequency = domainEvent.ExcerciseFrequency;
            IsSmoker = domainEvent.IsSmoker;
            CurrentMedications = domainEvent.CurrentMedications;
            PreviousAilments = domainEvent.PreviousAilments;
            GeneralPractionerName = domainEvent.GeneralPractionerName;
            MedicalClearance = domainEvent.MedicalClearance;
            HasHadPreviousTherapy = domainEvent.HasHadPreviousTherapy;
            TouchPreference = domainEvent.TouchPreference;
            ContraIndicationsArteriosclerosis = domainEvent.ContraIndicationsArteriosclerosis;

            ContraIndicationsArthritis = domainEvent.ContraIndicationsArthritis;
            ContraIndicationsAsthma = domainEvent.ContraIndicationsAsthma;
            ContraIndicationsCancer = domainEvent.ContraIndicationsCancer;
            ContraIndicationsColdOrFlu = domainEvent.ContraIndicationsColdOrFlu;
            ContraIndicationsContactLenses = domainEvent.ContraIndicationsContactLenses;
            ContraIndicationsCutsBurnsBruises = domainEvent.ContraIndicationsCutsBurnsBruises;
            ContraIndicationsDepression = domainEvent.ContraIndicationsDepression;
            ContraIndicationsDiabetes = domainEvent.ContraIndicationsDiabetes;
            ContraIndicationsDizziness = domainEvent.ContraIndicationsDizziness;
            ContraIndicationsEpilepsy = domainEvent.ContraIndicationsEpilepsy;
            ContraIndicationsHeadache = domainEvent.ContraIndicationsHeadache;
            ContraIndicationsHeartDisease = domainEvent.ContraIndicationsHeartDisease;
            ContraIndicationsHemophilia = domainEvent.ContraIndicationsHemophilia;
            ContraIndicationsHernia = domainEvent.ContraIndicationsHernia;
            ContraIndicationsHighBloodPressure = domainEvent.ContraIndicationsHighBloodPressure;
            ContraIndicationsImflammation = domainEvent.ContraIndicationsImflammation;
            ContraIndicationsIrritatedSkinRash = domainEvent.ContraIndicationsIrritatedSkinRash;
            ContraIndicationsIsPregnant = domainEvent.ContraIndicationsIsPregnant;
            ContraIndicationsLowBloodPressure = domainEvent.ContraIndicationsLowBloodPressure;
            ContraIndicationsMusculoskletalProblems = domainEvent.ContraIndicationsMusculoskletalProblems;
            ContraIndicationsPinsPacemaker = domainEvent.ContraIndicationsPinsPacemaker;
            ContraIndicationsSeverePain = domainEvent.ContraIndicationsSeverePain;
            ContraIndicationsSleepDisturbance = domainEvent.ContraIndicationsSleepDisturbance;
            ContraIndicationsStomachUlcers = domainEvent.ContraIndicationsStomachUlcers;
            ContraIndicationsSunburn = domainEvent.ContraIndicationsSunburn;
            ContraIndicationsVaricoseVeins = domainEvent.ContraIndicationsVaricoseVeins;

            CurrentStressLevels = domainEvent.CurrentStressLevels;
            CurrentPainOrTensionLevels = domainEvent.CurrentPainOrTensionLevels;
            AreasNotToBeMassaged = domainEvent.AreasNotToBeMassaged;
            TermsAndConditionsConditions1 = domainEvent.TermsAndConditionsConditions1;
            TermsAndConditionsConditions2 = domainEvent.TermsAndConditionsConditions2;
            TermsAndConditionsConditions3 = domainEvent.TermsAndConditionsConditions3;
            TermsAndConditionsConditions4 = domainEvent.TermsAndConditionsConditions4;
            TermsAndConditionsConditions5 = domainEvent.TermsAndConditionsConditions5;
            TermsAndConditionsConditions6 = domainEvent.TermsAndConditionsConditions6;
            TermsAndConditionsConditions7 = domainEvent.TermsAndConditionsConditions7;
            TermsAndConditionsConditions8 = domainEvent.TermsAndConditionsConditions8;
        }

        public void Apply(ClientUpdated domainEvent)
        {
            //TODO: refactor all this shitty code into one method..
            FirstName = domainEvent.FirstName;
            LastName = domainEvent.LastName;
            Gender = domainEvent.Gender;
            DateOfBirth = domainEvent.DateOfBirth;
            Email = domainEvent.Email;
            ContactNumber = domainEvent.ContactNumber;
            AddressLine1 = domainEvent.AddressLine1;
            AddressLine2 = domainEvent.AddressLine2;
            Suburb = domainEvent.Suburb;
            City = domainEvent.City;
            ExcerciseFrequency = domainEvent.ExcerciseFrequency;
            IsSmoker = domainEvent.IsSmoker;
            CurrentMedications = domainEvent.CurrentMedications;
            PreviousAilments = domainEvent.PreviousAilments;
            GeneralPractionerName = domainEvent.GeneralPractionerName;
            MedicalClearance = domainEvent.MedicalClearance;
            HasHadPreviousTherapy = domainEvent.HasHadPreviousTherapy;
            TouchPreference = domainEvent.TouchPreference;
            ContraIndicationsArteriosclerosis = domainEvent.ContraIndicationsArteriosclerosis;

            ContraIndicationsArthritis = domainEvent.ContraIndicationsArthritis;
            ContraIndicationsAsthma = domainEvent.ContraIndicationsAsthma;
            ContraIndicationsCancer = domainEvent.ContraIndicationsCancer;
            ContraIndicationsColdOrFlu = domainEvent.ContraIndicationsColdOrFlu;
            ContraIndicationsContactLenses = domainEvent.ContraIndicationsContactLenses;
            ContraIndicationsCutsBurnsBruises = domainEvent.ContraIndicationsCutsBurnsBruises;
            ContraIndicationsDepression = domainEvent.ContraIndicationsDepression;
            ContraIndicationsDiabetes = domainEvent.ContraIndicationsDiabetes;
            ContraIndicationsDizziness = domainEvent.ContraIndicationsDizziness;
            ContraIndicationsEpilepsy = domainEvent.ContraIndicationsEpilepsy;
            ContraIndicationsHeadache = domainEvent.ContraIndicationsHeadache;
            ContraIndicationsHeartDisease = domainEvent.ContraIndicationsHeartDisease;
            ContraIndicationsHemophilia = domainEvent.ContraIndicationsHemophilia;
            ContraIndicationsHernia = domainEvent.ContraIndicationsHernia;
            ContraIndicationsHighBloodPressure = domainEvent.ContraIndicationsHighBloodPressure;
            ContraIndicationsImflammation = domainEvent.ContraIndicationsImflammation;
            ContraIndicationsIrritatedSkinRash = domainEvent.ContraIndicationsIrritatedSkinRash;
            ContraIndicationsIsPregnant = domainEvent.ContraIndicationsIsPregnant;
            ContraIndicationsLowBloodPressure = domainEvent.ContraIndicationsLowBloodPressure;
            ContraIndicationsMusculoskletalProblems = domainEvent.ContraIndicationsMusculoskletalProblems;
            ContraIndicationsPinsPacemaker = domainEvent.ContraIndicationsPinsPacemaker;
            ContraIndicationsSeverePain = domainEvent.ContraIndicationsSeverePain;
            ContraIndicationsSleepDisturbance = domainEvent.ContraIndicationsSleepDisturbance;
            ContraIndicationsStomachUlcers = domainEvent.ContraIndicationsStomachUlcers;
            ContraIndicationsSunburn = domainEvent.ContraIndicationsSunburn;
            ContraIndicationsVaricoseVeins = domainEvent.ContraIndicationsVaricoseVeins;

            CurrentStressLevels = domainEvent.CurrentStressLevels;
            CurrentPainOrTensionLevels = domainEvent.CurrentPainOrTensionLevels;
            AreasNotToBeMassaged = domainEvent.AreasNotToBeMassaged;

           
        
        }

        public Guid OrganizationId { get; set; }

        public void Apply(SessionCreated sessionCreated)
        {
            SessionCount++;
        }
    }
}