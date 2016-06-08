using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DelegateDecompiler;

namespace Domain.Model
{
    public class Client : Entity, IAmLinkedToAnOrganization
    {
        public virtual Organization Organization { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Computed, NotMapped]
        public string FullName => FirstName + " " + LastName;

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

        [Range(0, 10)]
        public int CurrentStressLevels { get; set; }

        [Range(0, 10)]
        public int CurrentPainOrTensionLevels { get; set; }

        public string Difficuties { get; set; }
        public string AreasNotToBeMassaged { get; set; }
        public TermsAndConditions TermsAndConditions { get; set; }
        public virtual ICollection<Session> Sessions { get; set; }
        public int OrganizationId { get; set; }
    }
}