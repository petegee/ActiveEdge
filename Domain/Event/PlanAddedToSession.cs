using System;

namespace Domain.Event
{
    public class PlanAddedToSession
    {
        public Guid Id { get; set; }

        public string ContributingFactorsToCondition { get; set; }

        public string Hypothesis { get; set; }

        public string PreMassagePalpation { get; set; }

        public string SessionPlan { get; set; }

        public string TreatmentNotes { get; set; }

        public string UserId { get; set; }
    }
}
