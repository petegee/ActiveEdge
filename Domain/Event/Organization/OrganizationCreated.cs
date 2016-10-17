using System.Collections.Generic;
using Shared;

namespace Domain.Event.Organization
{
    public class OrganizationCreated : IDomainEvent, IOrganization
    {
        
        public string OrganizationName { get; set; }

        public string ContactPerson { get; set; }

        public string ContactPhoneNumber { get; set; }

        public string ContactEmailAddress { get; set; }

        public List<Clinic> Clinics { get; set; }
    }
}