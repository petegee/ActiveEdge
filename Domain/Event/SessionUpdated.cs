using System;
using System.Collections.Generic;

namespace Domain.Event
{
    public class SessionUpdated
    {
        public Guid Id { get; set; }

        public DateTime? Date { get; set; }

        public Guid ClientId { get; set; }

        public string ClientFullName { get; set; }

        public string Feedback { get; set; }

        public string GoalOrExpectations { get; set; }

        public string AreasOfDiscomfort { get; set; }

        public Guid? OrganizationId { get; set; }

        public string ContributingFactorsToCondition { get; set; }

        public string Hypothesis { get; set; }

        public string PreMassagePalpation { get; set; }
        
        public string TreatmentNotes { get; set; }

        public List<string> ContraIndications { get; set; }

        public string UserId { get; set; }
    }
}