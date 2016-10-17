using System;
using System.Collections.Generic;
using System.Linq;
using Shared;

namespace Domain.Event.Organization
{

    public class OrganizationUpdated : IDomainEvent, IOrganization, IHaveCities, IHaveSuburbs
    {
        public Guid Id { get; set; }

        public string OrganizationName { get; set; }

        public string ContactPerson { get; set; }

        public string ContactPhoneNumber { get; set; }

        public string ContactEmailAddress { get; set; }

        public List<Clinic> Clinics { get; set; }

        public string[] Cities
        {
            get
            {
                return Clinics?.Select(clinic => clinic.City).ToArray() ?? new string[0];
            }
        }

        public string[] Suburbs
        {
            get
            {
                return Clinics?.Select(clinic => clinic.Suburb).ToArray() ?? new string[0];
            }
        }
    }
}