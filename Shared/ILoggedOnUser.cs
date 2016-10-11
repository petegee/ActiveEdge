using System;

namespace Shared
{
    public interface ILoggedOnUser
    {
        Guid? OrganizationId { get; }
    }
}