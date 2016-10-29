using System;
using Marten.Schema;
using Shared;

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
}