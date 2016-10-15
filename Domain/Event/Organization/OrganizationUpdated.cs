using System.Collections.Generic;
using Shared;

namespace Domain.Event.Organization
{
    public class OrganizationUpdated : IDomainEvent
    {
        public int Id { get; set; }

        public string OrganizationName { get; set; }

        public string ContactPerson { get; set; }

        public string ContactPhoneNumber { get; set; }

        public string ContactEmailAddress { get; set; }

        public List<Clinic> Clinics { get; set; }
    }
}