using System;
using System.Collections.Generic;
using Shared;

namespace Domain.Event
{
    public class SessionCreated : IDomainEvent
    {
        public DateTime Date { get; set; }

        public Guid ClientId { get; set; }

        public string ClientFullName { get; set; }

        public string Feedback { get; set; }

        public string GoalOrExpectations { get; set; }

        public string AreasOfDiscomfort { get; set; }

        public Guid OrganizationId { get; set; }

        public List<string> ContraIndications { get; set; }
    }
}