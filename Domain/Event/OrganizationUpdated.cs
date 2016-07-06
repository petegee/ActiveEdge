using System.Collections.Generic;
using Shared;

namespace Domain.Event
{
    public class OrganizationUpdated : IDomainEvent
    {
        public int Id { get; set; }

        public string OrganizationName { get; set; }

        public string ContactPerson { get; set; }

        public string ContactPhoneNumber { get; set; }

        public string ContactEmailAddress { get; set; }

        public List<Clinic> Clinics { get; set; }

        public class Clinic
        {
            public int Id { get; set; }

            public string ClinicName { get; set; }

            public string AddressLine1 { get; set; }

            public string AddressLine2 { get; set; }

            public string Suburb { get; set; }

            public string City { get; set; }

            public string PostCode { get; set; }

            public string PhoneNumber { get; set; }
        }
    }
}