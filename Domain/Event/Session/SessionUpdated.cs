using System;
using System.Collections.Generic;
using Shared;

namespace Domain.Event.Session
{
    public class SessionUpdated: IDomainEvent, IAmAuditable
    {
        public Guid Id { get; set; }

        public DateTime? Date { get; set; }

        public Guid ClientId { get; set; }

        public string ClientFullName { get; set; }

        public string Feedback { get; set; }

        public string GoalOrExpectations { get; set; }

        public string AreasOfDiscomfort { get; set; }
        
        public string ContributingFactorsToCondition { get; set; }

        public string Hypothesis { get; set; }

        public string PreMassagePalpation { get; set; }
        
        public string TreatmentNotes { get; set; }

        public List<string> ContraIndications { get; set; }

        public DateTime CommandDate { get; set; }

        public string UserId { get; set; }

        public string UserName { get; set; }
    }
}