using System;

namespace Domain.Model
{
    public interface IAmLinkedToAnOrganization
    {
        Guid OrganizationId { get; set; }
    }
}