using System;
using System.Collections.Generic;
using Shared;

namespace Domain.Command.Organization
{
    public class UpdateOrganization : IAsyncCommand
    {
        public Guid Id { get; set; }

        public string OrganizationName { get; set; }

        public string ContactPerson { get; set; }

        public string ContactPhoneNumber { get; set; }

        public string ContactEmailAddress { get; set; }

        public List<Clinic> Clinics { get; set; }
       
    }
}