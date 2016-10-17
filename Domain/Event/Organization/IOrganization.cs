using System.Collections.Generic;

namespace Domain.Event.Organization
{
    public interface IOrganization
    {
        string OrganizationName { get; set; }
        string ContactPerson { get; set; }
        string ContactPhoneNumber { get; set; }
        string ContactEmailAddress { get; set; }
        List<Clinic> Clinics { get; set; }
    }
}