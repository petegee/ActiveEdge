using System;

namespace Shared
{
    public interface ILoggedOnUser
    {
        Guid? OrganizationId { get; }
        string Id { get; }
        string UserName { get; }
        bool IsAuthenticated { get; }
    }
}