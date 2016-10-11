using Domain.Event;

namespace Domain.Model
{
    public class Session : SessionBase
    {
        public string Feedback { get; set; }
        
        public string AreasOfDiscomfort { get; set; }

        public string ContributingFactorsToCondition { get; set; }

        public string PreMassagePalpatation { get; set; }

        public string Hypothesis { get; set; }

        public string SessionPlan { get; set; }
        
        public string TreatmentNotes { get; set; }

        public void Apply(SessionCreated domainEvent)
        {
            OrganizationId = domainEvent.OrganizationId;
            Date = domainEvent.Date;
            ClientId = domainEvent.ClientId;
            Feedback = domainEvent.Feedback;
            GoalOrExpectations = domainEvent.GoalOrExpectations;
            AreasOfDiscomfort = domainEvent.AreasOfDiscomfort;
        }
    }
}