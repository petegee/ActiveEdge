using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ActiveEdge.Read.Model.Session
{
    public class SessionPlanModel
    {
        public Guid Id { get; set; }

        [DisplayName("Contributing Factors To Condition")]
        public string ContributingFactorsToCondition { get; set; }

        [DisplayName("Hypothesis")]
        public string Hypothesis { get; set; }

        [DisplayName("Pre-Massage Palpation")]
        public string PreMassagePalpation { get; set; }

        [DisplayName("Session Plan")]
        [UIHint("Summernote")]
        public string SessionPlan { get; set; }

        [DisplayName("Treatment")]
        [UIHint("Summernote")]
        public string TreatmentNotes { get; set; }

    }
}