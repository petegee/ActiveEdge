using System;
using Shared;

namespace Domain.Command.Session
{
    
    public class AddPlanToSession : IAsyncCommand
    {
        public Guid Id { get; set; }

        public string ContributingFactorsToCondition { get; set; }

        public string Hypothesis { get; set; }

        public string PreMassagePalpation { get; set; }

        public string SessionPlan { get; set; }

        public string TreatmentNotes { get; set; }
    }
}