using System;
using Marten.Schema;

namespace Domain.Model
{

    public abstract class SessionBase : Entity, IAmLinkedToAnOrganization
    {
        [DuplicateField]
        public Guid OrganizationId { get; set; }
        
        public DateTime Date { get; set; }

        [DuplicateField]
        public Guid ClientId { get; set; }

        public string ClientFullName { get; set; }

        public string GoalOrExpectations { get; set; }

    }

    public class RemedialSession : SessionBase
    {
        public string MainConcerns { get; set; }

        public string History { get; set; }

        public string Complications { get; set; }

        public string FunctionalLimitations { get; set; }

    }
    public class Session : SessionBase
    {
        

        public string Feedback { get; set; }


        public string AreasOfDiscomfort { get; set; }

        public string ContributingFactorsToCondition { get; set; }

        public string PreMassagePalpatation { get; set; }

        public string Hypothesis { get; set; }

        public string SessionPlan { get; set; }
        
        public string TreatmentNotes { get; set; }

    }
}