using System;

namespace Domain.Command.Organization
{
    public class Clinic
    {
        public Guid Id { get; set; }

        public string ClinicName { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string Suburb { get; set; }

        public string City { get; set; }

        public string PostCode { get; set; }

        public string PhoneNumber { get; set; }
    }
}