using System;
using Shared;

namespace Domain.Event.Session
{
    public class PlanAddedToSession: IAmAuditable, IDomainEvent
    {
        public Guid Id { get; set; }

        public string ContributingFactorsToCondition { get; set; }

        public string Hypothesis { get; set; }

        public string PreMassagePalpation { get; set; }

        public string SessionPlan { get; set; }

        public string TreatmentNotes { get; set; }

        public DateTime CommandDate { get; set; }

        public string UserId { get; set; }

        public string UserName { get; set; }
    }
}
