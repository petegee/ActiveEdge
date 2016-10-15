using System;
using System.Collections.Generic;
using Shared;

namespace Domain.Command.Organization
{
    public class CreateNewOrganization : IAsyncCommand, IAmAuditable
    {
        public string OrganizationName { get; set; }

        public string ContactPerson { get; set; }

        public string ContactPhoneNumber { get; set; }

        public string ContactEmailAddress { get; set; }

        public List<Clinic> Clinics { get; set; }

        public DateTime CommandDate { get; set; }

        public string UserId { get; set; }

        public string UserName { get; set; }
    }
}