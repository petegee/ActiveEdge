using System;

namespace Shared
{
    public interface IAmLinkedToAnOrganization
    {
        Guid OrganizationId { get; set; }
    }
}