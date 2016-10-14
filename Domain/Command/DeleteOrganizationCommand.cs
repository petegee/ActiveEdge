using System;
using Shared;

namespace Domain.Command
{
    public class DeleteOrganizationCommand : ICommand
    {
        /// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
        public DeleteOrganizationCommand(Guid organizationId)
        {
            OrganizationId = organizationId;
        }

        public Guid OrganizationId { get; }
    }
}