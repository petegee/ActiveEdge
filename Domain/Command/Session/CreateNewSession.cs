using System;
using Shared;

namespace Domain.Command.Session
{
    public class CreateNewSession : IAsyncCommand
    {
        public DateTime? Date { get; set; }

        public Guid ClientId { get; set; }

        public string ClientFullName { get; set; }

        public string Feedback { get; set; }

        public string GoalOrExpectations { get; set; }

        public string AreasOfDiscomfort { get; set; }
        
        public Guid? OrganizationId { get; set; }
    }
}